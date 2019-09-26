var button;
var followingButton;
var AttendenceService = function () {
    var createAttendence = function (gigId, done, fail) {
        $.post("/api/attendences", { GigId: gigId })
            .done(done)
            .fail(fail);
    };
    var deleteAttendence = function (gigId, done, fail) {
        $.ajax({
            url: "/api/attendences/" + gigId,
            method: "DELETE"
        })
            .done(done)
            .fail(fail);
    };

    return {
        createAttendence: createAttendence,
        deleteAttendence: deleteAttendence
    }
}();
var gigsController = function (attendenceService) {

    var toggleAttendence = function (e) {
        button = $(e.target);
        var gigId = button.attr("data-gig-id");
        if (button.hasClass("btn-default"))
            attendenceService.createAttendence(gigId, done, fail);
        else
            attendenceService.deleteAttendence(gigId, done, fail);
    };
    var init = function (container) {
        $(container).on("click", ".js-toggle-attendence", toggleAttendence);

    };

    var fail = function () {
        alert("Something Unexpected Happens!");
    };
    var done = function () {
        var text = (button.text === "Going") ? "Going?" : "Going";
        button.toggleClass("btn-info").toggleClass("btn-default");
    };

    return {
        init: init
    }
}(AttendenceService);
var FollowingService = function () {
    var createFollowing = function (artistId, done, fail) {

        $.post("/api/followings", { followeeId: artistId }).done(done).fail(fail);
    } // end of createFollowing
    var deleteFollowing = function (artistId, done, fail) {
        $.ajax({
            url: "/api/followings/" + artistId,
            method: "DELETE"
        }).done(done).fail(fail);
    } // end of deleteFollowing function
    return {
        createFollowing: createFollowing,
        deleteFollowing: deleteFollowing
    }
}();
var followingController = function (followingService) {
    var done = function () {
        var text = followingButton.hasClass("btn-default") ? "followed" : "follow";
        followingButton.toggleClass("btn-default").toggleClass("btn-info").text(text);
    }
    var fail = function () {
        alert("something unexpected happened!");
    }
    var toggleFollowings = function (e) {
        alert('button clicked');
        followingButton = $(e.target);
        var followId = followingButton.attr("data-followings-id");
        if (followingButton.hasClass("btn-default")) {
            followingService.createFollowing(followId, done, fail);
        } else {
            followingService.deleteFollowing(followId, done, fail);
        }
    }
    var init = function () {
        $(".js-toggle-followings").click(toggleFollowings);
    }
    return {
        init: init
    }
}(FollowingService);