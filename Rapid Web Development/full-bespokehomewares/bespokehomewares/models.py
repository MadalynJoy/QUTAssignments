from datetime import datetime
from . import db

#All class attricutes

class Room(db.Model):
    __tablename__='rooms'
    id = db.Column(db.Integer, primary_key=True)
    name = db.Column(db.String(64), unique=True)
    image = db.Column(db.String(60), nullable=False, default = 'defaultroom.jpg')
    homewares = db.relationship('Homeware', backref='Room', cascade="all, delete-orphan")

    def __repr__(self):
        str = "ID: {}, Name: {}, Image: {} \n"
        str = str.format(self.id, self.name, self.image)
        return str

orderdetails = db.Table('orderdetails', 
    db.Column('order_id', db.Integer,db.ForeignKey('orders.id'), nullable=False),
    db.Column('homeware_id',db.Integer,db.ForeignKey('homewares.id'),nullable=False),
    db.PrimaryKeyConstraint('order_id', 'homeware_id') )


class Homeware(db.Model):
    __tablename__='homewares'
    id = db.Column(db.Integer, primary_key=True)
    name = db.Column(db.String(64),nullable=False)
    description = db.Column(db.String(500), nullable=False)
    image = db.Column(db.String(60), nullable=False)
    price = db.Column(db.Float, nullable=False)
    room_id = db.Column(db.Integer, db.ForeignKey('rooms.id'))
    
    def __repr__(self):
        str = "ID: {}, Name: {}, Description {}, Image: {}, Price: {}, Room: {}\n"
        str =str.format( self.id, self.name,self.description,self.image, self.price, self.room_id)
        return str

class Order(db.Model):
    __tablename__='orders'
    id = db.Column(db.Integer, primary_key=True)
    status = db.Column(db.Boolean, default=False)
    firstname = db.Column(db.String(64))
    surname = db.Column(db.String(64))
    email = db.Column(db.String(128))
    phone = db.Column(db.String(32))
    date = db.Column(db.DateTime)
    total_cost = db.Column(db.Float)
    homewares = db.relationship("Homeware", secondary=orderdetails, backref="orders")

    def __repr__(self):
        str = "ID: {}, Status: {}, Firstname: {}, Surname: {}, Email: {}, Phone: {}, Date: {}, Total Cost: {}, Homewares: {}\n"
        str =str.format( self.id, self.status,self.firstname,self.surname, self.email, self.phone, self.date, self.total_cost, self.homewares)
        return str
