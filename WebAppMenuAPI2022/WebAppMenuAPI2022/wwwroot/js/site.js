$(document).ready(function () {
    $.ajax({
        url: 'https://localhost:7050/api/Menu/GetMenu',
        type: 'GET',
        success: function (data1) {
            var html = '';
            for (var index = 0; index < data1.length; index++) {
                console.log(data1[index]);
                html += ('<option value="' + data1[index].menuID + '">' + data1[index].cusine + '</option>');
            }
            $('#menuList').append(html);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("Status: " + textStatus);
            alert("Error: " + errorThrown);
        }
    });

    $('#menuList').change(function () {
        var menuselected = $('#menuList').val();
        //alert(menuselected);
        $.ajax({
            url: 'https://localhost:7050/api/Menu/GetChoice',
            type: 'GET',
            success: function (data1) {
                var html = '<option value=" ">' + "Select" + '</option>';
                for (var index = 0; index < data1.length; index++) {
                    console.log(data1[index]);
                    html += ('<option value="' + data1[index].choiceID + '">' + data1[index].category + '</option>');
                }
                $('#choiceList').html(html);
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alert("Status: " + textStatus);
                alert("Error: " + errorThrown);
            }
        });

    });
    $('#choiceList').change(function () {
        var choiceList = $('#choiceList').val();
        //alert(choiceList);
        var menuselected = $('#menuList').val();
        $.ajax({
            url: 'https://localhost:7050/api/Menu/GetMenuCard?Mid=' + menuselected + '&Cid=' + choiceList,

            type: 'GET',
            success: function (data1) {
                var html = '';
                for (var index = 0; index < data1.length; index++) {
                    console.log(data1[index]);
                    html += ('<tr>' +
                        '<td>' + data1[index].dishId + '</td>' +
                        '<td>' + data1[index].dish + '</td>' +
                        '<td>' + data1[index].price + '</td>' +
                        '</tr>');
                }
                $('#tbody').html(html);
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alert("Status: " + textStatus);
                alert("Error: " + errorThrown);
            }
        });
    });
    $('#btnSubmit').click(function () {

        var dishname = $('#dname').val();
        var dishprice = $('#dpice').val();
        var menuid = $('input:radio[name=cusine]:checked').val();
        var choiceid = $('input:radio[name=choice]:checked').val();

        var formdata = {
            DishId: 0,
            Dish: dishname,
            Price: dishprice,
            MenuID: menuid,
            ChoiceID: choiceid,
        };
        console.log(formdata);
        $.ajax({

            url: 'https://localhost:7050/api/Menu/AddDish',
            type: 'POST',
            data:formdata , //data=attribute
            success: function (response) { // response from api, not the attribute

                console.log(response);


            },

            error: function (XMLHttpRequest, textStatus, errorThrown) {
                console.log(XMLHttpRequest);
                alert("Status: " + textStatus);
                alert("Error: " + errorThrown);

            }
        });

    });
});

function showDiv() {
    document.getElementById('addDish').style.display = "block";
}

