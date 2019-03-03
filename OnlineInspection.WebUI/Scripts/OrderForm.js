(function () {

    $(document).ready(function () {
        var counter = 0;

        $("#addrow").on("click", function () {
            var newRow = $("<tr>");
            var cols = "";

            cols += '<td><input type="text" class="form-control" name="Picture' + counter + '"/></td>';
            cols += '<td><input type="text" class="form-control" name="Description' + counter + '"/></td>';
           

            cols += '<td><input type="button" class="ibtnDel btn btn-md btn-danger "  value="Delete"></td>';
            newRow.append(cols);
            $("table.order-list").append(newRow);
            counter++;
        });



        $("table.order-list").on("click", ".ibtnDel", function (event) {
            $(this).closest("tr").remove();
            counter -= 1
        });


    });


    function calculateRow(row) {
        var price = +row.find('input[name^="price"]').val();

    }

    function calculateGrandTotal() {
        var grandTotal = 0;
        $("table.order-list").find('input[name^="price"]').each(function () {
            grandTotal += +$(this).val();
        });
        $("#grandtotal").text(grandTotal.toFixed(2));
    }


    //$(function () {

    //    bindEvents();

    //})

    //function bindEvents() {
    //    $("form").on("submit", onSubmit);
    //}

    //function onSubmit(e) {
    //    e.preventDefault();

    //    var productData = readForm();
    //    sendForm(productData).done(handleProductSaved);
    //}

    //function sendForm(productData) {
    //    return $.ajax({
    //        url: '/product/ProductFormJson',
    //        type: 'post',
    //        dataType: 'json',
    //        contentType: 'application/json',
    //        data: JSON.stringify(productData)
    //    });
    //}

    //function handleProductSaved(data) {
    //    if (data.Success) {
    //        toastr.success("Product succesfully saved.");
    //        $("form").trigger("reset");
    //    }
    //    else {
    //        toastr.error(data.Message, "Error on the page!");
    //    }
    //}

    //function readForm() {
    //    return {
    //        Product_Code: $("#Product_Code").val(),
    //        Image: $("imagem").val(),     

    //        Image: $("#inputGroupFileAddon01").val(),     
    //        Image: $("#inputGroupFile01").val(),   
    //    }
    //}


})();