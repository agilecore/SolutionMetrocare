$(document).ready(function () {
        
    $("#form-dependente").validate({
        rules: {
            nome: { required: true, maxlength: 100 },
            logradouro: { required: true, maxlength: 100 },
            complemento: { required: true, maxlength: 100 },
            numero: {
                required: true,
                min: 1,
                maxlength: 1,
                maxlength: 5,
                number: true
            },
            uf: { required: true },
            cep: {
                required: true,
                min: 1,
                minlength: 8,
                maxlength: 8,
                number: true
            },
            bairro: { required: true, maxlength: 100 },
            cidade: { required: true, maxlength: 100 },
            cpf: { required: true },
            rg: { required: true },
            telefone: { required: true },
            celular: { required: true },
            email: { required: true, email: true },
            latitude: { required: false, number: true },
            longitude: { required: false, number: true },
            ibge: { required: false, number: true }
        },
        messages: {
            nome: { required: '', maxlength: '' },
            logradouro: { required: '', maxlength: '' },
            complemento: { required: '', maxlength: '' },
            numero: { required: '', minlength: '', maxlength: '', min: '' },
            bairro: { required: '', maxlength: '' },
            cidade: { required: '', maxlength: '' },
            uf: { required: '' },
            cep: { required: '', minlength: '', maxlength: '', min: '' },
            cpf: { required: '' },
            rg: { required: '' },
            telefone: { required: '' },
            celular: { required: '' },
            email: { required: '', maxlength: '', email: '' },
            latitude: { required: '' },
            longitude: { required: '' },
            ibge: { required: '' }
        },
        highlight: function (element) {
            $(element).closest('.form-group').removeClass("has-success").addClass('has-error');
            addMask();
            //Metrocare.stopPageLoading();
        },
        unhighlight: function (element) {
            $(element).closest('.form-group').removeClass("has-error").addClass('has-success');
            Metrocare.stopPageLoading();
        },
        invalidHandler: function (event, validator) {
            if (!validator.numberOfInvalids()) { return; }
            $('html, body').animate({ scrollTop: $(validator.errorList[0].element).offset().top - 100 }, 700);
            //Metrocare.stopPageLoading();
        },
        errorElement: "div",
        submitHandler: function (form) {
            form.submit();
        },
        debug:false
    });

    addMask();
    addEventKeydown();

    // [ok]
    function addMask() {
        $("#telefone").inputmask("mask", {
            "mask": "(99) 9999-9999"
        });

        $("#celular").inputmask("mask", {
            "mask": "(99) 99999-9999"
        });

        $("#cpf").inputmask("mask", {
            "mask": "999.999.999-99"
        });

        $("#rg").inputmask("mask", {
            "mask": "99.999.999-9"
        });
    }

    // [ok]
    function addEventKeydown() {

        $("#numero").keydown(function (e) {
            if ($.inArray(e.keyCode, [46, 8, 9, 27, 13, 110, 190]) !== -1 ||
               (e.keyCode === 65 && (e.ctrlKey === true || e.metaKey === true)) ||
               (e.keyCode >= 35 && e.keyCode <= 40)) {
                return;
            }

            if ((e.shiftKey || (e.keyCode < 48 || e.keyCode > 57)) && (e.keyCode < 96 || e.keyCode > 105)) { e.preventDefault(); }
        });

        //$("#cep").keydown(function (e) {
        //    if ($.inArray(e.keyCode, [46, 8, 9, 27, 13, 110, 190]) !== -1 ||
        //       (e.keyCode === 65 && (e.ctrlKey === true || e.metaKey === true)) ||
        //       (e.keyCode >= 35 && e.keyCode <= 40)) {
        //        return;
        //    }

        //    if ((e.shiftKey || (e.keyCode < 48 || e.keyCode > 57)) && (e.keyCode < 96 || e.keyCode > 105)) { e.preventDefault(); }
        //});

        //$("#cpf").keydown(function (e) {
        //    if ($.inArray(e.keyCode, [46, 8, 9, 27, 13, 110, 190]) !== -1 ||
        //       (e.keyCode === 65 && (e.ctrlKey === true || e.metaKey === true)) ||
        //       (e.keyCode >= 35 && e.keyCode <= 40)) {
        //        return;
        //    }

        //    if ((e.shiftKey || (e.keyCode < 48 || e.keyCode > 57)) && (e.keyCode < 96 || e.keyCode > 105)) { e.preventDefault(); }
        //});

        //$("#cnpj").keydown(function (e) {
        //    if ($.inArray(e.keyCode, [46, 8, 9, 27, 13, 110, 190]) !== -1 ||
        //       (e.keyCode === 65 && (e.ctrlKey === true || e.metaKey === true)) ||
        //       (e.keyCode >= 35 && e.keyCode <= 40)) {
        //        return;
        //    }

        //    if ((e.shiftKey || (e.keyCode < 48 || e.keyCode > 57)) && (e.keyCode < 96 || e.keyCode > 105)) { e.preventDefault(); }
        //});

        $("#longitude").keydown(function (e) {
            if ($.inArray(e.keyCode, [46, 8, 9, 27, 13, 110, 190]) !== -1 ||
               (e.keyCode === 65 && (e.ctrlKey === true || e.metaKey === true)) ||
               (e.keyCode >= 35 && e.keyCode <= 40)) {
                return;
            }

            if ((e.shiftKey || (e.keyCode < 48 || e.keyCode > 57)) && (e.keyCode < 96 || e.keyCode > 105)) { e.preventDefault(); }
        });

        $("#latitude").keydown(function (e) {
            if ($.inArray(e.keyCode, [46, 8, 9, 27, 13, 110, 190]) !== -1 ||
               (e.keyCode === 65 && (e.ctrlKey === true || e.metaKey === true)) ||
               (e.keyCode >= 35 && e.keyCode <= 40)) {
                return;
            }

            if ((e.shiftKey || (e.keyCode < 48 || e.keyCode > 57)) && (e.keyCode < 96 || e.keyCode > 105)) { e.preventDefault(); }
        });

        $("#ibge").keydown(function (e) {
            if ($.inArray(e.keyCode, [46, 8, 9, 27, 13, 110, 190]) !== -1 ||
               (e.keyCode === 65 && (e.ctrlKey === true || e.metaKey === true)) ||
               (e.keyCode >= 35 && e.keyCode <= 40)) {
                return;
            }

            if ((e.shiftKey || (e.keyCode < 48 || e.keyCode > 57)) && (e.keyCode < 96 || e.keyCode > 105)) { e.preventDefault(); }
        });
    }

});


