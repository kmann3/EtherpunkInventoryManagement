# EtherpunkInventoryManagement

Inventory (IT - hardware/software) management system.

EtherpunkInventoryManagement's (EPIM) goal is to help IT folks of smaller organizations keep track of hardware and software.
Perhaps one day it might implement a helpdesk/ticket system.
The goal is to keep it simple and not overcomplicate things while still offering power to help customize things (e.g. you upgrade a particular model to a larger drive or take notes about how the ethernet port on a system died).
The ability to audit and keep track of licensing is also a part of the goal.
Currently the alternatives are expensive or not very clean.

## Overview of tools

Programmed in Visual Studio 2019 / C# / .NET Core 3.0.


## Database

The database chosen was SQLite but Postgre is an option in the future.
SQLite keeps things controlled and in a small area. Until helpdesk/ticket managing happens there shuldn't be enough writes/reads to cause troubles or db locks.

To recreate the database run the following:

1. Delete everything inside of the Migrations folder.
2. Delete InventoryDb.sqlite3
3. Open up Package Manager Console inside of Visual Studio
4. Run the following commands
   1. add-migration init
   2. update-database

## Checklist

* Dashboards
  * Tech
    * Recently entered items
    * Unvalidated items - highlite late items
    * Validated items by users and it/super's
  * Superviser
    * Recently entered items
    * Unvalidated items that are late
    * Recently disposed items
    * Quick access to reports
  * User
    * Items to validate
    * Items already validated but offer to re-validate
  * Administrator
    * Check for updates
* Hardware Inventory
  * Edit
  * Delete
  * Dispose
  * Orphan
  * Create
  * Mass Create
* Software Inventory (not implemented at all yet)
* Template Management
  * A template can be hardware and software
* User Management
  * Self?
  * Administrator
* Vendors
* Search
* Reports
  * Recently Assigned Items
  * Disposed Items
  * Deleted Items
  * Orphaned Items
  * User History
  * Item Assignemnt History
  * Item Full Report
  * Vendor List
  * User Audit
  * IT Audit
  * Important Action Items (e.g. late validations, a lot of orphaned items, hard delete requests (accidents))
* Administrative
  * Backup/Restore
  * Export
  * Active Directory Inegration
  * Manual User Management
    * Import list of users
* iOS/Android Version
  * Quick Assignment tool
  * QR Code scan for auditing and history