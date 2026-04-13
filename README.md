# Smart-Logistics-Delivery-System-

Task 1 → CORE OOP + VEHICLES
Responsibility:
System backbone + vehicles logic

#Classes to implement:
Entity (abstract)
Vehicle (abstract)
Truck
Van
Drone

#Methods:
Validate()
SetCapacity()
GetRemainingCapacity()
CalculateEfficiency()
Deliver()

#Algorithms:
Vehicle efficiency logic
Delivery logic (heavy vs medium vs light packages)

++++++++++++++++++++++++++++++++++++++++++++++++++

TAsk B → WORKERS + SYSTEM + DATA
Responsibility:
System logic + management + algorithms

#Classes:
Worker (abstract)
Driver
Manager
Loader
Package
Warehouse
DeliverySystem

#Methods:
CalculatePerformance()
PerformTask()
FindBestWorker()
AddPackage()
SearchPackageById()
SortPackages()
ProcessDeliveries()

#Algorithms:
Worker selection
Sorting algorithm 
Searching algorithm
Simulation logic

++++++++++++++++++++++++++++++++++++++++++++

#SHARED WORK (DO TOGETHER)

#Data Structures
CustomQueue<T> → package waiting system
CustomStack<T> → undo system

#Interfaces
IFileHandler
ISortable
IQueueable<T>

#Exception Classes
InvalidDataException
OverCapacityException
EmptyStructureException

#File Handling
Save / Load system

#Menu
Add entities
Assign deliveries
Search
Sort
Simulation
Undo
