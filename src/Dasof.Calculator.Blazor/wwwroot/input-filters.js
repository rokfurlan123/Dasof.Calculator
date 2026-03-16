(function () {
    function isDecimalOnlyInput(target) {
        return target instanceof HTMLInputElement && target.dataset.decimalOnly === "true";
    }

    function sanitizeDecimalText(rawText) {
        if (!rawText || !rawText.trim()) {
            return "";
        }

        const separatorIndex = getDecimalSeparatorIndex(rawText);
        let sanitized = "";
        let fractionDigits = 0;

        for (let index = 0; index < rawText.length; index++) {
            const character = rawText[index];

            if (character >= "0" && character <= "9") {
                if (separatorIndex < 0 || index < separatorIndex || fractionDigits < 2) {
                    sanitized += character;

                    if (separatorIndex >= 0 && index > separatorIndex) {
                        fractionDigits++;
                    }
                }

                continue;
            }

            if (index === separatorIndex) {
                if (!sanitized) {
                    sanitized = "0";
                }

                sanitized += ",";
            }
        }

        return sanitized;
    }

    function getDecimalSeparatorIndex(rawText) {
        const lastComma = rawText.lastIndexOf(",");
        const lastDot = rawText.lastIndexOf(".");

        if (lastComma >= 0 && lastDot >= 0) {
            return Math.max(lastComma, lastDot);
        }

        if (lastComma >= 0) {
            return lastComma;
        }

        if (lastDot < 0) {
            return -1;
        }

        let digitsAfterDot = 0;

        for (let index = lastDot + 1; index < rawText.length; index++) {
            const character = rawText[index];

            if (character >= "0" && character <= "9") {
                digitsAfterDot++;
            }
        }

        return digitsAfterDot <= 2 ? lastDot : -1;
    }

    function sanitizeInputValue(target) {
        const sanitizedValue = sanitizeDecimalText(target.value);

        if (target.value !== sanitizedValue) {
            target.value = sanitizedValue;
        }
    }

    document.addEventListener("input", function (event) {
        if (!isDecimalOnlyInput(event.target)) {
            return;
        }

        sanitizeInputValue(event.target);
    }, true);
})();
