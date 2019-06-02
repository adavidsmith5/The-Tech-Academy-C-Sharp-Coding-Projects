var vm = function (income, rent, water, electric, other) {
    this.income = ko.observable(income),
        this.rent = ko.observable(rent),
        this.water = ko.observable(water),
        this.electric = ko.observable(electric),
        this.other = ko.observable(other),
        this.budget = ko.pureComputed(function () {
            return this.income() - this.rent() - this.water() - this.electric() - this.other()
        }, this);
};

ko.applyBindings(new vm(0,0,0,0,0));
