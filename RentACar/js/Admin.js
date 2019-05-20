$(document).ready(function () {

 
    $("#frmTenant").submit(function (e) {
        e.preventDefault();
        var formData = new FormData(this);

        $.ajax({
            url: "/Admin/TenantCreate",
            type: "POST",
            data: formData,
            mimeType: "multipart/form-data",
            contentType: false,
            cache: false,
            processData: false,

            success: function (data, textStatus, jqXHR) {


                var jsonResult = JSON.parse(data);
                console.log(jsonResult);
                if (jsonResult) {
                    console.log(jsonResult);
                    var html = '<tr>' +
                        '<td></td>' +
                        '<td>' + jsonResult.Id + '</td>' +
                        '<td>' + jsonResult.Brand + '</td>' +
                        '<td>' + jsonResult.Model + '</td>' +
                        '<td>' + jsonResult.Gear + '</td>' +
                        '<td></td>' +
                        '</tr>';
                    $("#tblCarList").find("tbody").append(html);
                }
            }
        });
    });

    $('tenantbutton').click(function () {
        var confirmcreate = confirm("Kayıt Eklemek İstediğinize Emin Misiniz?");
        if (confirmcreate) {
        }
    });















    $("#frmCarSearch").submit(function (e) {
        e.preventDefault();
        var formData = new FormData(this);

        $.ajax({
            url: "/Admin/MovieSearch",
            type: "POST",
            data: formData,
            mimeType: "multipart/form-data",
            contentType: false,
            cache: false,
            processData: false,
            success: function (data, textStatus, jqXHR) {
                debugger;

                var jsonResult = JSON.parse(data);
                console.log(jsonResult);
                if (jsonResult) {
                    console.log(jsonResult);
                    $("#tblCarList").find("tbody").html("");

                    $.each(jsonResult, function (index, value) {

                        var html = '<tr>' +
                            '<td> <a href="/Admin/Edit/' + value.Id + '">Edit</a></td>' +
                            '<td>' + value.Id + '</td>' +
                            '<td>' + value.Brand + '</td>' +
                            '<td>' + value.Model + '</td>' +
                            '<td>' + value.Gear + '</td>' +
                            '<td><a class="btn btn-primary delete-row" data-id="' + value.Id +'">Sil</a></td>' +
                            '</tr>';
                        $("#tblCarList").find("tbody").append(html);
                    });

                }
            }
        });
    });

    $("#frmCarCreate").submit(function (e) {
        e.preventDefault();
        var formData = new FormData(this);

        $.ajax({
            url: "/Admin/Create",
            type: "POST",
            data: formData,
            mimeType: "multipart/form-data",
            contentType: false,
            cache: false,
            processData: false,

            success: function (data, textStatus, jqXHR) {


                var jsonResult = JSON.parse(data);
                console.log(jsonResult);
                if (jsonResult) {
                    console.log(jsonResult);
                    var html = '<tr>' +
                        '<td></td>' +
                        '<td>' + jsonResult.Id + '</td>' +
                        '<td>' + jsonResult.Brand + '</td>' +
                        '<td>' + jsonResult.Model + '</td>' +
                        '<td>' + jsonResult.Gear + '</td>' +
                        '<td></td>' +
                        '</tr>';
                    $("#tblCarList").find("tbody").append(html);
                }
            }
        });
    });


    $(document).on("click", ".delete-row", function () {
        var confirmdelete = confirm("Silme işlemini onaylıyor musunuz?");
        if (confirmdelete) {
            var Id = $(this).attr("data-id");

            var deleteTr = $(this).closest("tr");
            $.ajax({
                url: "/Admin/Delete/" + Id,
                type: "POST",
                success: function (result) {

                    if (result == 1) {
                        deleteTr.remove();
                    }
                    else {
                        alert("İşlem sırasında hata oluştu");
                    }
                }
            });
        }
    });







});