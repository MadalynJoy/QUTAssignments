from flask import Blueprint
from . import db
from .models import Room, Homeware, Order
import datetime

bp = Blueprint('admin', __name__, url_prefix='/admin/')

@bp.route('/dbseed/')
def dbseed():
    room1 = Room(name='Bedroom', image='bedroom.jpg')
    room2 = Room(name='Kitchen', image='kitchen.jpg')
    room3 = Room(name='Bathroom', image = 'bathroom.jpg')
  
    try:
        db.session.add(room1)
        db.session.add(room2)
        db.session.add(room3)
        db.session.commit()
    except:
        return 'There was an issue adding the room in dbseed function'

    #room1 = bedroom homewares
    h1 = Homeware(room_id=room1.id, image='quilt.jpg', price=220.00, name='Palm Tree Quilt',\
        description= '300 thread quilt cover. King size.') 
    h2 = Homeware(room_id=room1.id, image='mirror.jpg', price=660.00, name='Golden Arch Mirror',\
        description= 'Free standing mirror with golden finishes. Height = 1.8m.') 
    h3 = Homeware(room_id=room1.id, image='tablelamp.jpg', price=99.00, name='Brass Table Lamp',\
        description= 'Touch lamp with metal finishes and a milky light shade') 

    #room2 = kitchen homewares
    h4 = Homeware(room_id=room2.id, image='bakeware.jpg', price=55.00, name='Gilded Bakeware',\
        description= 'A bakeware set of multiple sizes. Golden finishes.') 
    h5 = Homeware(room_id=room2.id, image='tray.jpg', price=120.00, name='Mirrored Tray',\
        description= 'Mirrored finish for the base of the tray with metal handles. 30cm in diameter.') 
    h6 = Homeware(room_id=room2.id, image='cheeseboard.jpg', price=150.00, name='Marbled Cheeseboard',\
        description= 'Marbled board. Variations in stone may occur. 30cm in diameter.') 

    #room3 = bathroom homewares
    h7 = Homeware(room_id=room3.id, image='towels.jpg', price=50.00, name='Cotton Towels',\
        description= 'Extra large towels. Ethically sourced cotton')
    h8 = Homeware(room_id=room3.id, image='porcelain.jpg', price=29.00, name='Porcelain Vanity Accessories',\
        description= 'Recycled porcelain bathroom accessories. Includes toothbrush holder, soap dish, and much more.')
    h9 = Homeware(room_id=room3.id, image='hamper.jpg', price=99.99, name='Bamboo Woven Hamper',\
        description= 'Made from ethically sourced bamboo. Hand woven. Fair Trade.')

    try:
        db.session.add(h1)
        db.session.add(h2)
        db.session.add(h3)
        db.session.add(h4)
        db.session.add(h5)
        db.session.add(h6)
        db.session.add(h7)
        db.session.add(h8)
        db.session.add(h9)
        db.session.commit()
    except:
        return 'There was an issue adding a homeware in dbseed function'

    return 'DATA LOADED'
