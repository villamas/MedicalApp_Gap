    // Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
    // for details on configuring this project to bundle and minify static web assets.

    // Write your JavaScript code.

    <script charset="utf-8">
    $('#BtnLoggin').click(function (e) {        
            $.ajax({
                contentType: "application/json; charset=utf-8",
                type: "POST",
                url: "/api/seguridad/authenticate",
                data: JSON.stringify({
                    Username: document.getElementById('Username').value,
                    Password: document.getElementById('Password').value
                }),
                success: function (data, textStatus, jqXHR) {
                    $.post("/Home/Login2", null, jqXHR.responseText);


                },
                error: function (jqXHR, textStatus, errorThrown) {
                    alert("Error");
                    $("#postResult").val(jqXHR.statusText);
                }
            });
        });
</script>  