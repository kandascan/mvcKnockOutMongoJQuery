function Product(data) {
    this.name = ko.observable(data.name);
    this.quantity = ko.observable(data.quantity);
    this.price = ko.observable(data.price);
    this.subtotal = ko.pureComputed(function () {
        return this.quantity() * this.price();
    },
        this);
}

function ViewModel() {
    var self = this;
    self.products = ko.observableArray([]);

    self.grandTotal = ko.pureComputed(function () {
        var total = 0;
        $.each(self.products(), function () { total += Number(this.subtotal()) });
        return total;
    });

    self.priceTotal = ko.pureComputed(function () {
        var total = 0;
        $.each(self.products(), function () { total += Number(this.price()) });
        return total;
    });

    self.quantityTotal = ko.pureComputed(function () {
        var total = 0;
        $.each(self.products(), function () { total += Number(this.quantity()) });
        return total;
    });

    self.addProduct = function () {
        self.products.push(new Product({ name: "New Product", quantity: 10, price: 10 }));
    };

    self.removeProduct = function (product) { self.products.remove(product) };

    $.getJSON("/Product/GetProducts",
        function (allData) {
            var mappedProducts = $.map(allData, function (item) { return new Product(item) });
            self.products(mappedProducts);
        });
}

ko.applyBindings(new ViewModel());
