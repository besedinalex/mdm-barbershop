# Barbershop Consumables Control

An app for a *Master Data Management* discipline.

The purpose of the app is to grant certain barbershop's employees an automated system for accounting current consumables situation on a warehouse and keeping track of orders for new ones.

## Features

- SQLite database via Entity Framework.
- Windows Forms based UI.

**System administrator:**
- View users.
- Create user.
- Edit user's info.
- Delete user.

**Accountant:**
- View consumables info.
- Add consumables info (name, amount).
- Edit consumables info (name, amount).
- Delete consumables info.
- View suppliers info.
- Add supplier info (Goverment Registration Code, name, contact number).
- Edit supplier info (name, contact number).
- Delete supplier info.
- Create order (supplier, consumables, price).
- Edit order (consumables, price).
- Delete order.

**Administrator:**
- View consumables info.
- View suppliers info.
- Edit order info (mark it done when it is).
- Edit consumables info (amount).
