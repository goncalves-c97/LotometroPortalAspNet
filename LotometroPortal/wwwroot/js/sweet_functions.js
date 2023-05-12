class SweetFunctions {

    SweetError(titleValue, textValue) {
        swal(titleValue, textValue, "error")
    }

    SweetWarning(titleValue, textValue) {
        swal(titleValue, textValue, "warning")
    }

    SweetSuccess(titleValue, textValue) {
        swal(titleValue, textValue, "success")
    }

    SweetInfo(titleValue, textValue) {
        swal(titleValue, textValue, "info")
    }

    SweetInDevelopment() {
        swal('Função em desenvolvimento', 'Por favor, aguarde as próximas atualizações =)', "info")
    }

    SweetConfirmation(titleValue, textValue, positiveValue, negativeValue) {
        swal({
            title: titleValue,
            text: textValue,
            icon: "info",
            buttons: {
                negative: {
                    text: negativeValue,
                    value: 'negative'
                },
                positive: {
                    text: positiveValue,
                    value: 'positive'
                }
            }
        }).then((value) => {
            switch (value) {

                case 'negative':
                    return false;
                    break;

                case "positive":
                    return true;
                    break;

                default:
                    break;
            }
        });
    }

    SweetConfirmation(titleValue, textValue, positiveValue, negativeValue, positiveHref) {
        swal({
            title: titleValue,
            text: textValue,
            icon: "info",
            buttons: {
                positive: {
                    text: positiveValue,
                    value: 'positive'
                },
                negative: {
                    text: negativeValue,
                    value: 'negative'
                }
            }
        }).then((value) => {
            switch (value) {

                case 'negative':
                    return false;

                case "positive":
                    window.location = positiveHref;
                    return true;

                default:
                    break;
            }
        });
    }

    SweetSuccessRedirect(titleValue, textValue, positiveValue, positiveHref) {
        swal({
            title: titleValue,
            text: textValue,
            icon: "success",
            buttons: {
                positive: {
                    text: positiveValue,
                    value: 'positive'
                }
            }
        }).then((value) => {
            window.location = positiveHref;
            return true;
        });
    }

    SweetErrorBack(titleValue, textValue, positiveValue, indexBack) {
        swal({
            title: titleValue,
            text: textValue,
            icon: "error",
            buttons: {
                positive: {
                    text: positiveValue,
                    value: 'positive'
                }
            }
        }).then((value) => {
            history.go(indexBack);
            return true;
        });
    }
}

var sweetFunctions = new SweetFunctions();

function SweetConfirmationRedirect(ev, titleValue, textValue, positiveValue, negativeValue) {
    ev.preventDefault();
    var urlToRedirect = ev.currentTarget.getAttribute('href');

    swal({
        title: titleValue,
        text: textValue,
        icon: "warning",
        buttons: {
            positive: {
                text: positiveValue,
                value: 's'
            },
            negative: {
                text: negativeValue,
                value: 'n'
            },
        }
    }).then((value) => {
        switch (value) {

            case 'n':
                return false;

            case "s":
                window.location = urlToRedirect;
        }
    });
}

function SweetPostBudgetAnswer(ev) {
    ev.preventDefault();
    var urlToRedirect = ev.currentTarget.getAttribute('href');

    swal({
        title: 'Enviar orçamento',
        text: 'Deseja realmente enviar a resposta de orçamento?',
        icon: "warning",
        buttons: {
            negative: {
                text: 'Não',
                value: 'negative'
            },
            positive: {
                text: 'Sim',
                value: 'positive'
            }
        }
    }).then((value) => {
        switch (value) {

            case 'negative':
                return false;

            case "positive":
                window.location = urlToRedirect;
        }
    });
}

