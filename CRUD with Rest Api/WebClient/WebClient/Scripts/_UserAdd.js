
$("#btnRegister").click(function () {
    var kullanici = new Object();
    kullanici.KullaniciAdi = $("#txtRegisterName").val();
    kullanici.Mail = $("#txtRegisterMail").val();
    kullanici.Parola = $("#txtRegisterParola").val();
          //console.log(kullanici);
    $.ajax({    
        type: "post",
        dataType: "json",
        data: kullanici,
        url: "http://localhost:1103/api/User/PostKullanici",
        success: function (result) {
            if (result === "basarili")
                alert("Basarili");
            else
                alert("Basarisiz");
        }
    });
});
