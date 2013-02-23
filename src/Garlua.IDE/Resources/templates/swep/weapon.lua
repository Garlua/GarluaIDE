if SERVER then // This is where the init.lua stuff goes.
 
	//This makes sure clients download the file
	AddCSLuaFile ("shared.lua")
 
	//How heavy the SWep is
	SWEP.Weight = 5
 
	//Allow automatic switching to/from this weapon when weapons are picked up
	SWEP.AutoSwitchTo = false
	SWEP.AutoSwitchFrom = false
 
elseif CLIENT then // This is where the cl_init.lua stuff goes
 
	//The name of the SWep, as appears in the weapons tab in the spawn menu(Q Menu)
	SWEP.PrintName = "{{PrintName}}"
 
	//Sets the position of the weapon in the switching menu 
	//(appears when you use the scroll wheel or keys 1-6 by default)
	SWEP.Slot = 4
	SWEP.SlotPos = 1
 
	//Sets drawing the ammuntion levels for this weapon
	SWEP.DrawAmmo = {{DrawAmmo}}
 
	//Sets the drawing of the crosshair when this weapon is deployed
	SWEP.DrawCrosshair = {{DrawCrosshairs}}
 
	//Ensures a clean looking notification when a chair is undone. How it works:
	//When you create an undo, you specify the ID:
	//		undo.Create("Some_Identity")
	//By creating an associated language, we can make the undo notification look better:
	//		language.Add("Undone_Some_Identity", "Some message...")
 
	language.Add("Undone_Thrown_SWEP_Entity", "Undone Thrown SWEP Entity")
end
 
SWEP.Author = "{{Author}}"
SWEP.Contact = "{{Contact}}"
SWEP.Purpose = "{{Purpose}}"
SWEP.Instructions = "{{Instructions}}"
 
//The category that you SWep will be shown in, in the Spawn (Q) Menu 
//(This can be anything, GMod will create the categories for you)
SWEP.Category = "{{Category}}"
 
SWEP.Spawnable = {{SpawnableByPlayers}} -- Whether regular players can see it
SWEP.AdminSpawnable = {{SpawnableByAdmins}} -- Whether Admins/Super Admins can see it
 
SWEP.ViewModel = "{{ViewModel}}" -- This is the model used for clients to see in first person.
SWEP.WorldModel = "models/weapons/w_rocket_launcher.mdl" -- This is the model shown to all other clients and in third-person.
 
 
//This determins how big each clip/magazine for the gun is. You can 
//set it to -1 to disable the ammo system, meaning primary ammo will 
//not be displayed and will not be affected.
SWEP.Primary.ClipSize = {{PrimaryWeapon.ClipSize}}
 
//This sets the number of rounds in the clip when you first get the gun. Again it can be set to -1.
SWEP.Primary.DefaultClip = {{PrimaryWeapon.DefaultClip}}
 
//Obvious. Determines whether the primary fire is automatic. This should be true/false
SWEP.Primary.Automatic = {{PrimaryWeapon.Automatic}}
 
//Sets the ammunition type the gun uses, see below for a list of types.
SWEP.Primary.Ammo = "{{PrimaryWeapon.Ammo}}"

SWEP.Primary.Recoil = {{PrimaryWeapon.Recoil}}
SWEP.Primary.Damage = {{PrimaryWeapon.Damage}} 
SWEP.Primary.NumShots = {{PrimaryWeapon.NumberOfShots}}
SWEP.Primary.Cone = {{PrimaryWeapon.Cone}}
SWEP.Primary.Delay = {{PrimaryWeapon.Delay}}
 

SWEP.Secondary.ClipSize = {{SecondaryWeapon.ClipSize}}
SWEP.Secondary.DefaultClip = {{SecondaryWeapon.DefaultClip}}
SWEP.Secondary.Automatic = {{SecondaryWeapon.Automatic}}
SWEP.Secondary.Ammo = "{{SecondaryWeapon.Ammo}}"
SWEP.Secondary.Recoil = {{SecondaryWeapon.Recoil}}
SWEP.Secondary.Damage = {{SecondaryWeapon.Damage}} 
SWEP.Secondary.NumShots = {{SecondaryWeapon.NumberOfShots}}
SWEP.Secondary.Cone = {{SecondaryWeapon.Cone}}
SWEP.Secondary.Delay = {{SecondaryWeapon.Delay}}
 
//When the script loads, the sound ''Metal.SawbladeStick'' will be precached, 
//and a local variable with the sound name created.
local ShootSound = Sound("Metal.SawbladeStick")
 
function SWEP:Reload()
end
 
function SWEP:Think()
end
 
 
function SWEP:throw_attack (model_file)
	//Get an eye trace. This basically draws an invisible line from
	//the players eye. This SWep makes very little use of the trace, except to 
	//calculate the amount of force to apply to the object thrown.
	local tr = self.Owner:GetEyeTrace()
 
	//Play some noises/effects using the sound we precached earlier
	self:EmitSound(ShootSound)
	self.BaseClass.ShootEffects(self)
 
	//We now exit if this function is not running serverside
	if (!SERVER) then return end
 
	//The next task is to create a physics prop based on the supplied model
	local ent = ents.Create("prop_physics")
	ent:SetModel(model_file)
 
	//Set the initial position and angles of the object. This might need some fine tuning;
	//but it seems to work for the models I have tried.
	ent:SetPos(self.Owner:EyePos() + (self.Owner:GetAimVector() * 16))
	ent:SetAngles(self.Owner:EyeAngles())
	ent:Spawn()
 
	//Now we need to get the physics object for our entity so we can apply a force to it
	local phys = ent:GetPhysicsObject()
 
	//Check if the physics object is valid. If not, remove the entity and stop the function
	if !(phys && IsValid(phys)) then ent:Remove() return end
 
	//Time to apply the force. My method for doing this was almost entirely empirical 
	//and it seems to work fairly intuitively with chairs.
	phys:ApplyForceCenter(self.Owner:GetAimVector():GetNormalized() *  math.pow(tr.HitPos:Length(), 3))
 
	//Now for the important part of adding the spawned objects to the undo and cleanup lists.
	cleanup.Add(self.Owner, "props", ent)
 
	undo.Create ("Thrown_SWEP_Entity")
		undo.AddEntity (ent)
		undo.SetPlayer (self.Owner)
	undo.Finish()
end
 
 
//Throw an office chair on primary attack
function SWEP:PrimaryAttack()
	//Call the throw attack function, with the office chair model
	self:throw_attack("models/props/cs_office/Chair_office.mdl")
end
 
//Throw a wooden chair on secondary attack
function SWEP:SecondaryAttack()
	//Call the throw attack function, this time with the wooden chair model
	self:throw_attack("models/props_c17/FurnitureChair001a.mdl")
end