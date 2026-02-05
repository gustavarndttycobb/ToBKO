-- Insert Facilities (Parent and Children)
-- IDs are assumed or explicitly set if auto-increment allows (usually safer to let DB handle it if strictly auto-inc, but for scripts explicit IDs are better if possible. 
-- Since EF Core usually uses Identity, we will just insert values and let IDs be generated, but we need to know IDs for Foreign Keys.
-- To reliably link them in a script without variables (for broad compatibility), we must assume the tables are empty (reset) or use subqueries.
-- We'll assume the tables were just cleaned.

-- 1. Main Plant (Parent)
INSERT INTO Facilities (Name, IsWorking, TimeRunning, ParentId)
VALUES ('Main Plant', 1, NOW(), NULL);

-- Get ID of Main Plant for children (assuming it's the first one inserted after truncation, so ID usually 1, but let's use a variable to be safe in MySQL)
SET @MainPlantId = LAST_INSERT_ID();

-- 2. Warehouse (Independent)
INSERT INTO Facilities (Name, IsWorking, TimeRunning, ParentId)
VALUES ('Warehouse', 1, NOW(), NULL);
SET @WarehouseId = LAST_INSERT_ID();


-- 3. Assembly Line A (Child of Main Plant)
INSERT INTO Facilities (Name, IsWorking, TimeRunning, ParentId)
VALUES ('Assembly Line A', 1, NOW(), @MainPlantId);
SET @AssemblyLineAId = LAST_INSERT_ID();

-- 4. Assembly Line B (Child of Main Plant)
INSERT INTO Facilities (Name, IsWorking, TimeRunning, ParentId)
VALUES ('Assembly Line B', 0, NOW(), @MainPlantId);
SET @AssemblyLineBId = LAST_INSERT_ID();


-- Insert Equipments

-- Equipments for Assembly Line A
INSERT INTO Equipments (Name, Description, SerialNumber, IsOperational, FacilityId)
VALUES 
('Conveyor Belt 101', 'Main conveyor for line A', 'CB-101-A', 1, @AssemblyLineAId),
('Robot Arm Alpha', 'Welding robot', 'RA-001', 1, @AssemblyLineAId);

-- Equipments for Assembly Line B
INSERT INTO Equipments (Name, Description, SerialNumber, IsOperational, FacilityId)
VALUES 
('Sorting Machine', 'Optical sorter', 'SM-2024', 0, @AssemblyLineBId);

-- Equipments for Warehouse
INSERT INTO Equipments (Name, Description, SerialNumber, IsOperational, FacilityId)
VALUES 
('Forklift X1', 'Heavy duty forklift', 'FL-555', 1, @WarehouseId),
('Pallet Jack', 'Manual pallet jack', 'PJ-01', 1, @WarehouseId);