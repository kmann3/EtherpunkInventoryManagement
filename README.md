# EtherpunkInventoryManagement
Inventory (IT - hardware/software) management system.

EtherpunkInventoryManagement's (EPIM) goal is to help IT folks of smaller organizations keep track of hardware and software.
Perhaps one day it might implement a helpdesk/ticket system.
The goal is to keep it simple and not overcomplicate things while still offering power to help customize things (e.g. you upgrade a particular model to a larger drive or take notes about how the ethernet port on a system died).
The ability to audit and keep track of licensing is also a part of the goal.
Currently the alternatives are expensive or not very clean.

## Database
The database chosen was SQLite but Postgre is an option in the future.
SQLite keeps things controlled and in a small area. Until helpdesk/ticket managing happens there shuldn't be enough writes/reads to cause troubles or db locks.

To recreate the database run the following:

1. Delete everything inside of the Migrations folder.
2. Delete InventoryDb.sqlite3
3. Open up Package Manager Console inside of Visual Studio
4. Run the following commands
5. 1. add-migration init
   2. update-database

## Checklist
(need to work on this, it's a copy/paste from an old file)
<ul>
    <li><a href="/Home/Index">Home / Dashboard</a></li>
    <li><a href="/Home/RoadMap">Road Map</a></li>
    <li><a href="/Home/Contact">Contact</a> -- Access for support and whatnot</li>
    <li>Inventory - <a href="/Inventory/Details/@Model.InventoryId_Long">Details</a> [ID: @Model.InventoryId_Long]</a></li>
    <li>Inventory - <a href="/Inventory/Details/@Model.InventoryId_Short">Details</a> [ID: @Model.InventoryId_Short]</a> - Easily spoken numbers and letters. Short ID chosen to ignore confusing letters and numbers. Certain ones removed such as O and 0. L and 1.</li>
    <li>Inventory - <a href="/Inventory/Edit/@Model.InventoryId_Long">Edit</a></li>
    <li>Inventory - <a href="/Inventory/Reassign/@Model.InventoryId_Long">Reassign</a></li>
    <li>Inventory - <a href="/Inventory/Delete/@Model.InventoryId_Long">Delete</a></li>
    <li>Inventory - <a href="/Inventory/Dispose/@Model.InventoryId_Long">Dispose</a></li>
    <li>Inventory - <a href="/Inventory/Delete/@Model.InventoryId_Long">Create</a></li>
    <li>Inventory - <a href="/Inventory/Delete/@Model.InventoryId_Long">Mass Create</a></li>
    <li>Template Management - <a href="#">Index</a></li>
    <li>Template Management - <a href="/Templates/CopyMod/@Model.InventoryId_Long">CopyMod</a> - Used when you make a change to something. It copies the old template into a new one, then modifies the properties accordingly. Example: Dell XPS 150 4GB of RAM -> 8GB of RAM. This is sent an InventoryId and will infer the template and then replace that inentory item with that new modified template.</li>
    <li>Template Management - <a href="/Templates/Delete/@Model.InventoryTemplateId">Delete</a> - Requires moving to a new template or orphaning hardware?</li>
    <li><strike>Template Management - <a href="/Templates/Retire/@Model.InventoryTemplateId">Retire</a> - Retires a template so it can no longer be used but still shown for historical purposes. Those that are retired will no longer be shown in the "create" list. This is useful for a discontinued product that you simply don't want on your list anymore.</strike></li>
    <li>User - <a href="#">Create</a></li>
    <li>User - <a href="#">AD / LDAP Management?</a></li>
    <li>User - <a href="#">Delete</a> -- soft delete if it orphans records</li>
    <li>User - <a href="#">Edit</a></li>
    <li>User - <a href="#">Assigned Inventory</a></li>
    <li>Reports - <a href="#">Recently Assigned Items</a></li>
    <li>Reports - <a href="#">Disposed Items</a></li>
    <li>Reports - <a href="#">Deleted Items</a></li>
    <li>Reports - <a href="#">Orphaned Items</a></li>
    <li>Reports - <a href="#">User History</a></li>
    <li>Reports - <a href="#">Item Assignment History</a></li>
    <li>Reports - <a href="#">Item Full Report</a></li>
    <li>Reports - <a href="#">Vendor List</a></li>
    <li>Reports - <a href="#">User Audit</a></li>
    <li>Reports - <a href="#">IT Audit</a></li>
    <li>Reports - <a href="#">Important Action Items</a> (Things that require action, things you shouldn't ignore; automate this)</li>
    <li>Data Management - <a href="#">Backup</a></li>
    <li>Data Management - <a href="#">Restore</a></li>
    <li>Mobile - <a href="#">Tool for IT Validating an entire location</a> - "Full Audit". Provides tools to help reconcile problems.</li>
    <li>Mobile - <a href="#">Quick Assignment Tool</a></li>
    <li>Mobile - <a href="#">QR Code scan</a> - Pull information out about item</li>
</ul>
