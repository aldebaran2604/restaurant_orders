const STATUS_PENDING = 0;
const STATUS_IN_PROCESS = 1;
const STATUS_COMPLETED = 2;
const STATUS_DELIVERED = 3;
const STATUS_CANCELED = 4;


const loadOrdersByStatus = function (orders) {
    orders.forEach(element => {
        let contentPanel = $("#template_panel").html();
        contentPanel = contentPanel.replace(/{order_id}/g, element.folioNumber);
        contentPanel = contentPanel.replace(/{status_cancel}/g, STATUS_CANCELED.toString());

        switch (element.orderStatus) {
            case STATUS_PENDING:
                contentPanel = contentPanel.replace(/{status_new}/g, STATUS_IN_PROCESS.toString());
                $("#pending").html($("#pending").html() + contentPanel);
                break;
            case STATUS_IN_PROCESS:
                contentPanel = contentPanel.replace(/{status_new}/g, STATUS_COMPLETED.toString());
                $("#in_Process").html($("#in_Process").html() + contentPanel);
                break;
            case STATUS_COMPLETED:
                contentPanel = contentPanel.replace(/{status_new}/g, STATUS_DELIVERED.toString());
                $("#completed").html($("#completed").html() + contentPanel);
                break;
            case STATUS_DELIVERED:
                removeButtons(element.folioNumber);
                $("#delivered").html($("#delivered").html() + contentPanel);
                break;
            case STATUS_CANCELED:
                removeButtons(element.folioNumber);
                $("#canceled").html($("#canceled").html() + contentPanel);
                break;
        }

        loadOrderDetails(element.orderDetails, element.folioNumber);
    });
}

const loadOrderDetails = function (details, folioNumber) {
    details.forEach(element => {
        let contentDetails = $("#template_details").html();
        contentDetails = contentDetails.replace(/{product_name}/g, element.productName);
        contentDetails = contentDetails.replace(/{product_quantity}/g, element.quantity);
        $("#details_" + folioNumber).html($("#details_" + folioNumber).html() + contentDetails);
    });
}

const removeButtons = function (folioNumber) {
    setTimeout(function() {
        $("#buttons_" + folioNumber).remove();
    }, 100);
}

const changeStatusOrder = function (folioNumber, status) {
    $.ajax({
        url: "https://localhost:7041/api/Orders/" + folioNumber + "/" + status,
        type: 'PUT'
    }).then(function (data) {
        if (data.success) {
            loadOrderAndDetails();
        } else {
            Swal.fire(data.message);
        }
    });
}

const cleanTabs = function () {
    $("#pending").html("");
    $("#in_Process").html("");
    $("#completed").html("");
    $("#delivered").html("");
    $("#canceled").html("");
}

const loadOrderAndDetails = function () {
    cleanTabs();
    $.ajax({
        url: "https://localhost:7041/api/Orders"
    }).then(function (data) {
        if (data.success) {
            loadOrdersByStatus(data.resultItem);
        } else {
            Swal.fire(data.message);
        }
    });
}

$(document).ready(function () {
    loadOrderAndDetails();
});
