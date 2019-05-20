$(document).ready(function () {

$("#frmTenantCreate").submit(function (e) {
    e.preventDefault();
    var formData = new FormData(this);

    $.ajax({
        url: "/Home/TenantCreate",
        type: "POST",
        data: formData,
        mimeType: "multipart/form-data",
        contentType: false,
        cache: false,
        processData: false,

        success: function (data, textStatus, jqXHR) {

            $('#reservationModal').modal("hide");
            var jsonResult = JSON.parse(data);
            console.log(jsonResult);
            if (jsonResult) {
                console.log(jsonResult);
                var html = '<tr>' +
                    '<td></td>' +
                    '<td>' + jsonResult.MoviesName + '</td>' +
                    '<td>' + jsonResult.MovieSubject + '</td>' +
                    '<td>' + jsonResult.Production + '</td>' +
                    '<td>' + jsonResult.Director + '</td>' +
                    '<td>' + jsonResult.CategoryId + '</td>' +
                    '<td></td>' +
                    '</tr>';
                $("#tblMovieList").find("tbody").append(html);
      
            }
        }
      });
    });
});