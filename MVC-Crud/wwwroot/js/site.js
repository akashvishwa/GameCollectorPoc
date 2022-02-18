// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.







    //jqurerry to delete
    $(document).ready(function(){

        $(".delBtn").click(function(event){
        
            var formele=$(event.target).parent();

            var row=$(formele).parent().parent();

            var rowid=$(row).children("td:nth-child(1)").text();

            if(confirm("Are You Sure To delete the Game With ID : "+rowid)==1){

            $(formele).children(".del-Id").val(rowid);

            formele.submit();
            }
        });

    });
    


    //jquerry to edit form - data fill
    $(document).ready(function(){

               

        
        $(".editBtn").click(function(event){
            
            var ele=$(event.target).parent().parent();

             //check this tommorow    
             //$(ele).children("td:nth-child(1)").css({"color":"red"});
            


            var id= $(ele).children("td:nth-child(1)").text();
            var nameOfGame= $(ele).children("td:nth-child(2)").text();

            var noOfLevels= $(ele).children("td:nth-child(3)").text();
            var publisher= $(ele).children("td:nth-child(4)").text();
            var popularity= $(ele).children("td:nth-child(5)").text();

       

            $("#edit-Id").val(id);
            $("#edit-Name").val(nameOfGame);
            $("#edit-noOfLevels").val(noOfLevels);
            $("#edit-Publisher").val(publisher);
            $("#edit-Popularity").val(popularity);

          

            
        
        });

    });


    
  // /* $(document).ready(function(){
  //      $("#createBtn").click(function(){
  //      $("#overlay-create").slideDown("slow");
  //      });
  //  });
  //*/






// for Edit form submit

$(document).ready(function () {
    $("#EditSubmit").click(function () {
        $("#EditGameForm").submit();
    });
});







// jquerry to edit rank in rank page

$(document).ready(function () {

    $(".EditRankForm").click(function (eve) {

        var element = $(eve.target).parent().parent();

        var gameId = $(element).prevUntil(".TableChange").last().children(":nth-child(2)").text().trim();
        var gameName = $(element).prevUntil(".TableChange").last().children(":nth-child(4)").text().trim();

        var secondEle = $(eve.target).parent().parent();

        var profId = $(secondEle).children(":nth-child(1)").text();
        var gamerName = $(secondEle).children(":nth-child(2)").text();
        var rankId = $(secondEle).children(":nth-child(3)").text();
        var rank = $(secondEle).children(":nth-child(4)").text();


        $("#EditProfileId").val(profId);
        $("#EditGamerName").val(gamerName);
        $("#EditRankId").val(rankId);
        $("#EditRank").val(rank);
        $("#EditGameId").val(gameId);
        $("#EditGameName").val(gameName);

    });

});







