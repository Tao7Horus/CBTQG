var DVC_QuyenTacGia_SearchGiayChungNhan = function (options) {
    for (var property in options) {
        this[property] = options[property];
    }
    return this.Initialize(options);
}
DVC_QuyenTacGia_SearchGiayChungNhan.prototype = {
    Initialize: function (options) {
        this.RegisterEvent();
    },
    RegisterEvent: function () {
        var that = this;
        Common.Init();

        $("#btnSearchGiayChungNhan").unbind("click").click(function () {
            Common.DVC_QuyenTacGia_SearchGiayChungNhan.SubmitForm();
            return false;
        });

        $('.trGiayChungNhan').unbind("click").click(function () {
            var id = $(this).data("id");
            window.location.href = "/DVC_QuyenTacGia/" + $("#form-update-tt-tacpham").find("input[name='KeyPage']").val()
                + "?id=" + id
                + "&hoSoId=" + $("#form-update-tt-tacpham").find("input[name='QuyenTacGia.HoSoID']").val()
                + "&isMap=" + false;
            Common.DVC_QuyenTacGia_SearchGiayChungNhan.HideDialog();
            return false;
        });
    },
    SubmitForm: function () {
        var form = $("#idFormSearchGiayChungNhan");
        var pageIndex = $("#dialogSearchGiayChungNhan").find("input[name='PageIndex']").val() > 0 ? $("#dialogSearchGiayChungNhan").find("input[name='PageIndex']").val() : 1;
        var pageSize = $("#dialogSearchGiayChungNhan").find("input[name='PageSize']").val() > 0 ? $("#dialogSearchGiayChungNhan").find("input[name='PageSize']").val() : 10;
        var model = {
            pageIndex: pageIndex,
            pageSize: pageSize,
            TuKhoa: form.find("input[name='TuKhoa']").val() || null
        };
        var formdata = new FormData();
        formdata.append('modelSearch', JSON.stringify(model));
        Common.Ajax({
            type: 'POST',
            url: Common.DVC_QuyenTacGia_SearchGiayChungNhan.Url.SearchGiayChungNhan,
            data: formdata,
            contentType: false, // Not to set any content header
            processData: false, // Not to process data
            dataType: 'html',
        }, function (result) {
            $("#result-searchgiaychungnhan").empty();
            $("#result-searchgiaychungnhan").html(result);
            Common.DVC_QuyenTacGia_SearchGiayChungNhan.ShowDialog();
        });
        return false;
    },
    Paging: function (page) {
        Common.DVC_QuyenTacGia_SearchGiayChungNhan.SetPage(page);
        Common.DVC_QuyenTacGia_SearchGiayChungNhan.SubmitForm();
        return false;
    },
    SetPage: function (page) {
        $("#dialogSearchGiayChungNhan").find("input[name='PageIndex']").val(page);
    },
    SetPageSize: function (page) {
        $("#idFormSearchGiayChungNhan").find("input[name='PageSize']").val(page);
    },
    ChangePageSize: function (e) {
        Common.DVC_QuyenTacGia_SearchGiayChungNhan.SetPageSize($(e).val());
        Common.DVC_QuyenTacGia_SearchGiayChungNhan.SubmitForm();
        return false;
    },
    ShowDialog: function () {
        $("#dialogSearchGiayChungNhan").modal("show")
        Common.DVC_QuyenTacGia_SearchGiayChungNhan.RegisterEvent();
    },
    HideDialog: function () {
        $("#dialogSearchGiayChungNhan").modal("hide");
    },
};

var DVC_QuyenTacGia_SearchGiayChungNhan = DVC_QuyenTacGia_SearchGiayChungNhan;
DVC_QuyenTacGia_SearchGiayChungNhan.constructor = DVC_QuyenTacGia_SearchGiayChungNhan;
