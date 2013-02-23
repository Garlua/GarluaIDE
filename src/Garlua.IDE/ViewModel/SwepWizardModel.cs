using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garlua.IDE.ViewModel
{
    public class SwepWizardModel
    {
        public String Author { get; set; }
        public String Contact { get; set; }
        public String Purpose { get; set; }
        public String Instructions { get; set; }
        public Boolean DrawCrosshairs { get; set; }
        public Boolean DrawAmmo { get; set; }
        public String PrintName { get; set; }
        public String Category { get; set; }

        public Boolean SpawnableByPlayers { get; set; }
        public Boolean SpawnableByAdmins { get; set; }

        public string ViewModel { get; set; }

        public Model.ScriptableWeapon PrimaryWeapon { get; set; }
        public Model.ScriptableWeapon SecondaryWeapon { get; set; }

        public SwepWizardModel()
        {
            DrawCrosshairs = true;
            DrawAmmo = true;
            Category = "Custom";

            SpawnableByAdmins = true;
            SpawnableByPlayers = true;

            PrimaryWeapon = new Model.ScriptableWeapon();
            SecondaryWeapon = new Model.ScriptableWeapon();

            ViewModel = "models/weapons/v_RPG.mdl";
        }

        public override string ToString()
        {
            return String.Format("Author: {0}, Contact: {1}, Purpose: {2}, Instructions: {3}", Author, Contact, Purpose, Instructions);
        }
    }
}
