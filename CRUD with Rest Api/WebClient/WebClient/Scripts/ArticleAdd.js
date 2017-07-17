    $("#btnAdd").click(function () {
        var makale = new Object();
        makale.Baslik = $("#txtBaslik").val();
        makale.Icerik = $("#txtIcerik").val();

        console.log(makale);

        $.ajax({
            type: "post",
            dataType: "json",
            data: makale,
            url: "http://localhost:1103/api/Home/AddMakale",
            success: function (result) {
                if (result == "basarili")
                    alert("Eklendi.");
            }
        });
    });