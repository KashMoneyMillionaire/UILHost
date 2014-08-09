/// <reference path="bootbox.js" />

var validation = {}; //validation || {}; //validation namespace

(function (validation) {

    //#region local variables
    var _rules;
    var _ruleDefinitions;
    //#endregion

    //#region public functions
    validation.load = function (clientId, rules) {
        _rules = rules;
        getRuleDefinitions(clientId, function (json) {
            _ruleDefinitions = json;
        });
    };

    validation.check = function (fieldName, value) {
        var warningMessages = [];
        var field = _rules[fieldName];

        if (!field) {
            console.error("No such field: " + fieldName);
            return;
        }

        //check rules and create error messages
        field.rules.forEach(function (ruleName) {
            _ruleDefinitions.forEach(function (ruleDefinitionElement) {
                if (ruleName === ruleDefinitionElement.Type) {
                    var result = check.belowMax(fieldName, ruleDefinitionElement, value);//check["belowMax"](fieldName, ruleDefinitionElement, value);

                    if (!result.pass) {
                        warningMessages.push(result.message);
                    }
                }

            });
        });

        displayWarnings(warningMessages);
    };
    //#endregion

    //#region local functions and objects
    var serviceBase = '/Api/',
        getSvcUrl = function (method) { return serviceBase + method; };

    var getRuleDefinitions = function (clientId, callback) {

        bm.ajaxService.ajaxGetJson("PayrollValidationSvc/GetAllByClientId/" + clientId, callback, console.error)


        //$.ajax({
        //    url: getSvcUrl(),
        //    type: "GET",
        //    cache: false,
        //    dataType: "json",
        //    contentType: "application/json",
        //    success: function (json) {
        //        callback(json);
        //    },
        //    error: function (xhr, status, error) {
        //        console.error(xhr, status, error);
        //    }
        //});
    };

    var check = { //holds all check functions. created in case we use different kinds of functions in future, can call from ruleDefinitionElement.CheckType or something
        belowMax: function (fieldName, ruleDefinitionElement, value) {
            var occurance = _rules[fieldName].occurance;
            var ruleValue = ruleDefinitionElement[occurance];

            if (value > ruleValue) {
                return { pass: false, message: "The value " + value + " is above the suggested maximum of " + ruleValue + "." }; //failed
            }

            return { pass: true, message: "" }; //passed
        }
    };

    var displayWarnings = function (warningMessages) {
        if (warningMessages.length > 0) { //errors
            var message = "";

            warningMessages.forEach(function (warningMessage) {
                message += "--" + warningMessage + "\n";
            });

            bootbox.alert(message);
        }
    };
    //#endregion

    //#region testing
    var mockRules =
    {
        "NetPay": {
            "displayName": "Net Pay",
            "occurance": "Weekly",
            "rules": ["DollarsWarning", "NetPayWarning"]
        },
        "Insurance": {
            "occurance": "SemiMontly",
            "rules": ["DeductionsWarning", "DeductionsSection125Warning"]
        }
    };

    //Object
    //Annual: 100000.99
    //BiWeekly: 500
    //Monthly: 1000.99
    //Quarterly: 10001.99
    //SemiMonthly: 500
    //Type: "DollarsWarning"
    //Weekly: 250

    validation.load(2, mockRules);
    //#endregion

})(validation);