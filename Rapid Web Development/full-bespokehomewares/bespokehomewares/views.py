from flask import Blueprint, render_template, url_for, request, session, flash, redirect
from .models import Room, Homeware, Order
from datetime import datetime
from .forms import CheckoutForm
from . import db

bp = Blueprint('main', __name__)

#home page
@bp.route('/')
def index():
    return render_template('index.html')

#each room displayed
@bp.route('/rooms/')
def viewroom():
    rooms = Room.query.order_by(Room.name).all()
    return render_template('rooms.html', room = rooms)

#each homeware in set room displayed
@bp.route('/roomhomewares/<int:roomid>/')
def roomhomewares(roomid):
    homewares = Homeware.query.filter(Homeware.room_id == roomid)
    return render_template('roomhomewares.html', homewares = homewares)

# Basket info
@bp.route('/order', methods=['POST','GET'])
def order():
    homeware_id = request.values.get('homeware_id')

    # retrieve order
    if 'order_id'in session.keys():
        order = Order.query.get(session['order_id'])
    else:
        order = None

    # create new order
    if order is None:
        order = Order(status = False, firstname='', surname='', email='', phone='', date=datetime.now(), total_cost=0)
        try:
            db.session.add(order)
            db.session.commit()
            session['order_id'] = order.id
        #create order error
        except:
            print('Could not create a new order')
            order = None
    
    # calcultate total price
    totalprice = 0
    if order is not None:
        for homeware in order.homewares:
            totalprice = totalprice + homeware.price

    # Add item
    if homeware_id is not None and order is not None:
        homeware = Homeware.query.get(homeware_id)
        if homeware not in order.homewares:
            try:
                order.homewares.append(homeware)
                db.session.commit()
            except:
                return 'Error: Please try adding the item again'
            return redirect(url_for('main.order'))
        else:
            flash('This item has already been selected')
            return redirect(url_for('main.order'))
    
    return render_template('order.html', order = order, totalprice = totalprice)

# Delete basket item(s)
@bp.route('/deleteorderitem', methods=['POST'])
def deleteorderitem():
    id=request.form['id']
    if 'order_id' in session:
        order = Order.query.get_or_404(session['order_id'])
        homeware_to_delete = Homeware.query.get(id)
        try:
            order.homewares.remove(homeware_to_delete)
            db.session.commit()
            return redirect(url_for('main.order'))
        except:
            return 'Please try again'
    return redirect(url_for('main.order'))

# Clear basket
@bp.route('/deleteorder')
def deleteorder():
    if 'order_id' in session:
        del session['order_id']
        flash('Basket successfully cleared')
    return redirect(url_for('main.index'))

# Process order
@bp.route('/checkout', methods=['POST','GET'])
def checkout():
    form = CheckoutForm() 
    if 'order_id' in session:
        order = Order.query.get_or_404(session['order_id'])
       
        if form.validate_on_submit():
            order.status = True
            order.firstname = form.firstname.data
            order.surname = form.surname.data
            order.email = form.email.data
            order.cardnumber = form.cardnumber.data
            order.expiry = form.expiry.data
            order.cvv = form.cvv.data
            total_cost = 0
            for homeware in order.homewares:
                total_cost = total_cost + homeware.price
            order.total_cost = total_cost
            order.date = datetime.now()
            try:
                db.session.commit()
                del session['order_id']
                flash('Thank you for your order. A confirmation email will be sent shortly to your inbox')
                return redirect(url_for('main.index'))
            except:
                return 'Your order could not be processed. Please try again.'
    return render_template('checkout.html', form = form)

