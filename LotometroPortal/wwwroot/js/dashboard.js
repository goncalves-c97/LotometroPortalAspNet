$(document).ready(function () {
    var myChartFesa;

    function updateCameraFesa() {
        $.ajax({
            url: '/Dashboard/GetCameraInfo',
            type: 'GET'
        }).done(function (response) {

            var qtdPessoas = $("#qtdPessoasFesa");
            var percentualPessoas = $("#percentualFesa");
            var dataLeituraFesa = $("#dataLeituraFesa"); 

            qtdPessoas.text(response.numeroPessoas + ' pessoas');
            percentualPessoas.text(response.percentualDeLotacao);
            dataLeituraFesa.text(response.dataInformacao);

            if (typeof myChartFesa !== 'undefined')
                myChartFesa.destroy();

            ctx = document.getElementById("myChartFesa").getContext("2d");
            myChartFesa = new Chart(ctx, {
                type: "doughnut",
                data: {
                    labels: ["Ocupado", "Vazio"],
                    datasets: [
                        {
                            label: "Ocupação",
                            data: [response.numeroPessoas, (response.lotacaoMaxima - response.numeroPessoas)],
                            backgroundColor: [
                                "rgba(255, 99, 132, 0.8)",
                                "rgba(54, 162, 235, 0.8)",
                                "rgba(255, 206, 86, 0.8)",
                            ],
                            borderColor: [
                                "rgba(255, 99, 132, 1)",
                                "rgba(54, 162, 235, 1)",
                                "rgba(255, 206, 86, 1)",
                            ],
                            borderWidth: 1,
                        },
                    ],
                },
                options: {
                    responsive: true,
                    plugins: {
                        legend: {
                            position: "top",
                        },
                        title: {
                            display: true,
                            text: "Legenda",
                        },
                    },
                },
            });

            //$("#cameraContent").text(JSON.stringify(response));
        });
    }

    updateCameraFesa();
    setInterval(updateCameraFesa, 10000);

});