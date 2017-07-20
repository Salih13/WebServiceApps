
    $("#btnAdd").click(function () {
        var makale = new Object();
        makale.Baslik = $("#txtBaslik").val();
        makale.Icerik = $("#txtIcerik").val();
        makale.KullaniciID = 1;
        makale.KategoriID = 2;

  //      console.log(makale);

        $.ajax({
        type: "post",
            dataType: "json",
            data: makale,
            url: "http://localhost:1103/api/Article/PostMakale",
            success: function (result) {
                if (result == "basarili")
                    alert("Basarili");
            }
        });
    });
