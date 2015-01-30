var leaderboard = {
    firstPlayer: ko.observable(),
    secondPlayer: ko.observable(),
    selectPlayer: function (name) {
        if (this.firstPlayer() === name) {
            this.firstPlayer(null);
        } else if (this.firstPlayer() == null) {
            this.firstPlayer(name);
        } else {
            this.secondPlayer(name);
            $("#addGame").modal("show");
        }
    },
    isSelected: function (name) {
        return this.firstPlayer() === name || this.secondPlayer() == name;
    },
    clearSelection: function () {
        this.firstPlayer(null);
        this.secondPlayer(null);
    }
}

ko.applyBindings(leaderboard);
$('#addGame').on('hidden.bs.modal', function () {
    leaderboard.clearSelection();
})