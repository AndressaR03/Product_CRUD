//Load Data in Table when document is ready
$(document).ready(function () {
    loadData();
    loadCategoria();

});


function loadData() {
    $.ajax({
        url: "./List",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = '';
            $.each(result, function (key, item) {
                console.log(item);
                html += '<tr>';
                html += '<td>' + item.Id + '</td>';
                html += '<td>' + item.Nome + '</td>';
                html += '<td>' + item.Descricao + '</td>';
                html += '<td>' + item.Categoria + '</td>';
                html += '<td>' + item.Ativo + '</td>';
                html += '<td>' + item.Perecivel + '</td>';
                html += '<td><button type="button" class="btn btn-success"  onclick = "return getbyID(' + item.Id + ')">Atualizar</button><button type="button" class="btn btn-danger" onclick="return Delete(' + item.Id + ')">Deletar</button></td>';
                html += '</tr>';
            });
            $('.tbody').html(html);                
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
 
    });
}

function loadCategoria() {
    $.ajax({
        url: "./ListCategoria",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = '';
            $.each(result, function (key, item) {
                html += ' <option value=' + item.Id + '>' + item.Nome + '</option>';
            });
            $('.select').html(html);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

//Add Data Function
function Add() {
    var res = validate();
    if (res == false) {
        alert("Preencha todos os campos!!");
        return false;
    }

    var perecivel = $("#Perecivel").is(":checked") ? 1 : 0;

    var prodObj = {
        Nome: $("#Nome").val(),
        Descricao: $("#Descricao").val(),
        CategoriaID: $("#Categoria").val(),
        Perecivel: perecivel,
        Ativo: 1,
    };
    $.ajax({
        url: "./Add",
        data: JSON.stringify(prodObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            $(':input[type=text], textarea', '#form').not(':button, :submit, :reset, :hidden').val('').prop('checked', false);
            loadData();
            loadCategoria();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

//Function for getting the Data Based upon Product ID
function getbyID(ProdID) {
    $('#Name').css('border-color', 'lightgrey');
    $('#Descricao').css('border-color', 'lightgrey');
    $('#Categoria').css('border-color', 'lightgrey');
    $.ajax({
        url: "./getbyID/" + ProdID,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            $("#Id").val(result.Id);
            $("#Nome").val(result.Nome);
            $("#Descricao").val(result.Descricao);
            $('#Categoria').val(result.CategoriaID);
            $('#Perecivel').val(result.Perecivel);
            $('#btnUpdate').show();
            $('#btnAdd').hide();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}


//function for updating product
function Update() {
    var res = validate();
    if (res == false) {
        alert("Preencha todos os campos!!");
        return false;
    }

    var perecivel = $("#Perecivel").is(":checked") ? 1 : 0;

    var prodObj = {
        Id: $('#Id').val(),
        Nome: $('#Nome').val(),
        Descricao: $("#Descricao").val(),
        Ativo: 1,
        Perecivel: perecivel,
        CategoriaID: $("#Categoria").val(),
    };
    $.ajax({
        url: "./Update",
        data: JSON.stringify(prodObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            $(':input[type=text], textarea', '#form').not(':button, :submit, :reset').val('').prop('checked', false);
            $("#btnUpdate").hide();
            $("#btnAdd").show();
            loadData();
            loadCategoria();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

//Function for deleting a Product
function Delete(ID) {
    var confirmation = confirm("Tem certeza que deseja excluir esse Produto?");
    if (confirmation) {
        $.ajax({
            url: "./Delete/" + ID,
            type: "POST",
            contentType: "application/json;charset=UTF-8",
            dataType: "json",
            success: function (result) {
                loadData();
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        })
    }
}



//Validattion using Jquery
function validate() {
    var isValid = true;
    
    if ($('#Nome').val().trim() == "" ) {
        $('#Nome').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Nome').css('border-color', 'lightgrey');
    }
    if ($('#Descricao').val().trim() == "" ) {
        $('#Descricao').css('border-color', 'Red');
        isValid = false
    }
    else {
        $('#Descricao').css('border-color', 'lightgrey');
    }
    if ($('#Categoria').val().trim() == "") {
        $('#Categoria').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Categoria').css('border-color', 'lightgrey');
    }

    return isValid 
}

