(function () {
    
    //   $("#CreateButton").click(function () {         
    //       $.ajax({
    //           type: 'POST',
    //           url: '@Url.Content("~/Admin/CreateProblemDetailFill")',
    //           data: objectToPass,
    //           success: function (data) {
    //               var t = $("#ProductId").text();
    //               var q = $("#OrderId").text();                   
    //           }
    //       });
    //});


    //$(function () {

    //    bindEvents();

    //})

    //function bindEvents() {
    //    $("#CreateButton").click("submit", onSubmit);
    //}
    
    //function onSubmit(e) {
    //    e.preventDefault();
    //   // alert("teste do botao dentro da funcao certa");        

    //    var productData = readForm();
    //    sendForm(productData).done(handleProductSaved);    
    //}
    
   

    //function sendForm(productData) {
    //    return $.ajax({
    //        url: '/Admin/CreateProblemDetailFill',
    //        type: 'post',
    //        dataType: 'json',
    //        contentType: 'application/json',
    //        data: JSON.stringify(productData)

    //    });
    //}

    //function handleProductSaved(data) {
    //    if (data.Success) {
    //        toastr.success("Product succesfully saved.");
    //        //$("form").trigger("reset");
    //    }
    //    else {
    //        toastr.error(data.Message, "Error on the page!");
    //    }
    //}

    //function readForm() {
    //    var t = $("#ProductId").text();
    //    var q = $("#OrderId").text();
       
    //    return {           
    //        ProductId: t,
    //        OrderId: q,
    //    }
    //}




})();