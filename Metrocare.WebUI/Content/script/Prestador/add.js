$(document).ready(function () {

    $('#btnSave').click(function () {

        validForm();

        if ($("#form-prestador").valid())
        {
            Metrocare.startPageLoading();

            var values = { 
                id_prestador: $("#id_prestador").val(),
                nome: $("#nome").val(),
                cpf: $("#cpf").val(),
                cnpj: $("#cnpj").val(),
                email: $("#email").val(),
                logradouro: $("#logradouro").val(),
                complemento: $("#complemento").val(),
                numero: $("#numero").val(),
                cep: $("#cep").val(),
                bairro: $("#bairro").val(),
                cidade: $("#cidade").val(),
                uf: $("#uf").val(),
                telefone: $("#telefone").val(),
                celular: $("#celular").val(),
                contato: $("#contato").val(),
                dt_cadastro: $("#dt_cadastro").val(),
                longitude: $("#longitude").val(),
                latitude: $("#latitude").val(),
                ibge: $("#ibge").val() 
            };
            // 1. Salva os dados
            $.ajax({
                url:  '/Prestador/Save',
                type: 'POST',
                data: values,
                success: function (msg) {
                    // 2. Obtem a listagens
                    $.ajax({
                        url:  '/Prestador/List',
                        type: 'GET',
                        data: 'html',
                        success: function (data) {
                            //console.log('salvo com sucesso!');
                            $('#page-content').html(data);
                            Metrocare.stopPageLoading();
                        },
                        error: function (jqXHR, textStatus, errorThrown) {
                            //console.log('erro ao obter a lista! erro: ' + errorThrown);
                            $('#page-content').html('<h4>Não foi possível obter a listagem atual.</h4>');
                            Metrocare.stopPageLoading();
                        }
                    }); 
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    //console.log('não salvo! erro: ' + errorThrown);
                    $('#page-content').html('<h4>Não foi possível salvar o cadastro atual.</h4>');
                    Metrocare.stopPageLoading();
                }
            });
        }
    });

    $("#btnClear").click(function () {
        addClearForm();
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

        $("#cnpj").inputmask("mask", {
            "mask": "99.999.999/999-99"
        });
    }

    // [ok]
    function addClearForm()
    {
        Metrocare.startPageLoading();

        $("#id_prestador").val('');
        $("#nome").val('');
        $("#cpf").val('');
        $("#cnpj").val('');
        $("#email").val('');
        $("#logradouro").val('');
        $("#complemento").val('');
        $("#numero").val('');
        $("#cep").val('');
        $("#bairro").val('');
        $("#cidade").val('');
        $("#uf").val('');
        $("#telefone").val('');
        $("#celular").val('');
        $("#contato").val('');
        $("#dt_cadastro").val('');
        $("#longitude").val('');
        $("#latitude").val('');
        $("#ibge").val('');

        Metrocare.stopPageLoading();
    }

    // [ok]
    function addEventKeydown()
    {
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

    // [ok]
    function validForm()
    {
        $("#form-prestador").validate({
            rules: {
                nome: { required: true, maxlength: 100 },
                cpf: { required: true },
                cnpj: { required: false },
                email: { required: true, email: true },
                logradouro: { required: true, maxlength: 100 },
                complemento: { required: true, maxlength: 100 },
                numero: {
                    required: true,
                    min: 1,
                    maxlength: 1,
                    maxlength: 5,
                    number: true
                },
                cep: {
                    required: true,
                    min: 1,
                    minlength: 8,
                    maxlength: 8,
                    number: true
                },
                bairro: { required: true, maxlength: 100 },
                cidade: { required: true, maxlength: 100 },
                uf: { required: true },
                telefone: { required: true },
                celular: { required: true },
                contato: { required: true, maxlength: 100 },
                dt_cadastro: { required: true },
                longitude: { required: false, number: true },
                latitude: { required: false, number: true },
                ibge: { required: false, number: true }
            },
            messages: {
                nome: { required: '', maxlength: '' },
                cpf: { required: '' },
                cnpj: { minlength: '' },
                email: { required: '', maxlength: '', email: '' },
                logradouro: { required: '', maxlength: '' },
                complemento: { required: '', maxlength: '' },
                numero: { required: '', minlength: '', maxlength: '', min: '' },
                cep: { required: '', minlength: '', maxlength: '', min: '' },
                bairro: { required: '', maxlength: '' },
                cidade: { required: '', maxlength: '' },
                uf: { required: '' },
                telefone: { required: '' },
                celular: { required: '' },
                contato: { required: '', maxlength: '' },
                dt_cadastro: { required: '' },
                longitude: { required: '' },
                latitude: { required: '' },
                ibge: { required: '' }
            },
            highlight: function (element) {
                $(element).closest('.form-group').removeClass("has-success").addClass('has-error');
                addMask();
                Metrocare.stopPageLoading();
            },
            unhighlight: function (element) {
                $(element).closest('.form-group').removeClass("has-error").addClass('has-success');
                Metrocare.stopPageLoading();
            },
            invalidHandler: function (event, validator) {
                if (!validator.numberOfInvalids()) { return; }
                $('html, body').animate({ scrollTop: $(validator.errorList[0].element).offset().top - 100 }, 700);
                Metrocare.stopPageLoading();
            },
            errorElement: "div",
            submitHandler: function (form) { }
        });
    }

});