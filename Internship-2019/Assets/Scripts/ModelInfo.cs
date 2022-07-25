using System;

/*ModelInfo collect data of HET-atoms from database that store in format of PDB(Protein Data Bank)
 * Type is atom type (ATOMS or HETATM)
 * Element is name of atom (H, O, P, etc)
 * Radius is string that use to get radius of atom (O1A, O2A, PA, etc)
 * Bond is group or chain that atom refer to.
 * X,Y,Z is position of atom in 3D coordinate.
 */
public class ModelInfo
    {
        public string Type { get; set; }
        public string Element { get; set; }
        public string Radius { get; set; }
        public string Bond { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }


        public ModelInfo(string type, string element, string radius, string bond, float x, float y, float z) 
        {
            this.Type = type;
            this.Element = element;
            this.Radius = radius;
            this.Bond = bond;
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

    }
