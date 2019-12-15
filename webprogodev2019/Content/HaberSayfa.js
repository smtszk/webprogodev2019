function mainPage() {
    debugger;
    AjaxPost('Home/HaberSayfa',
        {

        }, function(data){
            alert("Geldi");
        });
    
}

function AjaxPost(url, a, f) {
    url = "/webprogodev2019/" + url;
    $.post(url, a, function (data) {
        if (f) {
            f(data);
        }
    }).error(function () {
        alert("Ajax call sırasında bir hata oluştu");
    });
}