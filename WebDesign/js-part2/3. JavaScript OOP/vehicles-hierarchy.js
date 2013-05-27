Function.prototype.inherit = function (parent) {
    this.prototype = new parent();
    this.prototype.constructor = parent;
};

Function.prototype.extend = function (parent) {
    for (var i = 1; i < arguments.length; i += 1) {
        var name = arguments[i];
        this.prototype[name] = parent.prototype[name];
    }
    return this;
}

/* Propulsion units inheritance */

Wheel.inherit(PropulsionUnit);
PropellingNozzle.inherit(PropulsionUnit);
Propeller.inherit(PropulsionUnit);

function PropulsionUnit() {
    this.accelerate = function () {
        alert("I'm meant to be overriden!");
    }
}

function Wheel(radius) {
    PropulsionUnit.apply(this, arguments);

    this.radius = radius;
    this.accelerate = function () {
        return (2 * Math.PI * this.radius);
    }
}

function PropellingNozzle(power, afterburnerTurned) {
    PropulsionUnit.apply(this, arguments);

    this.power = power;
    this.afterburnerTurned = afterburnerTurned;

    this.accelerate = function () {
        if (this.afterburnerTurned == true)
            return 2 * this.power;

        return this.power;
    }
}

function Propeller(fins, spinDirectionClockwise) {
    PropulsionUnit.apply(this, arguments);

    this.fins = parseInt(fins);
    this.spinDirectionClockwise = spinDirectionClockwise;

    this.accelerate = function () {
        return this.spinDirectionClockwise ? this.fins : -this.fins;
    }
}

/* Vehicle inheritance */

LandVehicle.inherit(Vehicle);
AirVehicle.inherit(Vehicle);
WaterVehicle.inherit(Vehicle);

function Vehicle(speed) {
    this.speed = speed;
}

function LandVehicle(speed, wheelRadius) {
    Vehicle.call(this, speed);

    this.wheels = [];

    for (var i = 0; i < 4; i++) {
        this.wheels.push(new Wheel(wheelRadius));
    }

    this.accelerate = function () {
        for (var i in this.wheels)
            this.speed += this.wheels[i].accelerate();
    }
}

function AirVehicle(speed, propellingNozzle) {
    Vehicle.call(this, speed);

    this.propellingNozzle = propellingNozzle;

    this.switchNozzleAfterburner = function () {
        if (this.propellingNozzle.afterburnerTurned == true)
            this.propellingNozzle.afterburnerTurned = false;
        else
            this.propellingNozzle.afterburnerTurned = true;
    }

    this.accelerate = function () {
        this.speed += propellingNozzle.accelerate();
    }
}

function WaterVehicle(speed, numberOfPropellers) {
    Vehicle.call(this, speed);

    this.propellers = [];

    for (var i = 0; i < numberOfPropellers; i++) {
        var fins = prompt("Enter propeller's number of fins: ");
        this.propellers.push(new Propeller(fins, true));
    }

    this.changePropellerDirection = function (propellerNumber) {
        if (propellerNumber > this.propellers.length || propellerNumber < 1) {
            alert("The vehicle doesn't have that many propellers!");
            return;
        }

        if (this.propellers[propellerNumber - 1].spinDirectionClockwise == true) {
            this.propellers[propellerNumber - 1].spinDirectionClockwise = false;
        }
        else {
            this.propellers[propellerNumber - 1].spinDirectionClockwise = true;
        }
    }

    this.accelerate = function () {
        for (var i in this.propellers)
            this.speed += this.propellers[i].accelerate();
    }
}

/* Multiple inheritance for amphibious vehicle */

AmphibiousVehicle.inherit(LandVehicle);
AmphibiousVehicle.inherit(WaterVehicle);

function AmphibiousVehicle(speed, wheelRadius, mode) {
    LandVehicle.call(this, speed, wheelRadius);
    WaterVehicle.call(this, speed, 1);
    
    this.mode = mode;

    this.switchMode = function () {
        if (this.mode == "land")
            this.mode = "water";
        else
            this.mode = "land";
    }

    this.accelerate = function () {
        if (this.mode == "land") {
            for (var i = 0; i < this.wheels.length - 1; i++) {
                this.speed += this.wheels[i].accelerate();
            }
        }
        else {
            this.speed += this.propellers[0].accelerate();
        }
    }
}

var amph = new AmphibiousVehicle(10, 5, "land");
console.log("Speed before: " + amph.speed);
amph.accelerate();
console.log("Speed in land mode: " + amph.speed);
amph.switchMode();
amph.accelerate();
console.log("Speed in water mode: " + amph.speed);

//var landVehicle = new LandVehicle(40, 5);
//console.log("Speed before: " + landVehicle.speed);
//landVehicle.accelerate();
//console.log("Speed after: " + landVehicle.speed);

//var airVehicle = new AirVehicle(50.24, new PropellingNozzle(10.11, false));
//console.log("Speed before: " + airVehicle.speed);
//airVehicle.accelerate();
//console.log("Speed after: " + airVehicle.speed);
//airVehicle.switchNozzleAfterburner();
//airVehicle.accelerate();
//console.log("Speed after switching afterburner: " + airVehicle.speed);

//var waterVehicle = new WaterVehicle(10, 3);

//console.log("Speed before: " + waterVehicle.speed);
//waterVehicle.accelerate();
//console.log("Speed after: " + waterVehicle.speed);
//waterVehicle.changePropellerDirection(2);
//waterVehicle.accelerate();
//console.log("Speed after changing direction: " + waterVehicle.speed);