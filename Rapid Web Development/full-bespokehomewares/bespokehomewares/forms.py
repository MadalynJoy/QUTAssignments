from flask_wtf import FlaskForm
from wtforms.fields import SubmitField, StringField
from wtforms.validators import InputRequired, email

# Form for processing order
class CheckoutForm(FlaskForm):
    firstname = StringField("First Name", validators=[InputRequired()])
    surname = StringField("Surname", validators=[InputRequired()])
    email = StringField("Email", validators=[InputRequired(), email()])
    phone = StringField("Phone Number", validators=[InputRequired()])
    address = StringField("Delivery Address", validators=[InputRequired()])
    cardnumber = StringField("Card Number", validators=[InputRequired()])
    expiry = StringField("Expiry Date", validators=[InputRequired()])
    cvv = StringField("CVV", validators=[InputRequired()])
    submit = SubmitField("Confirm Order")
