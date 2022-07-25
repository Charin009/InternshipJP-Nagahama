using System;

/* Radius collect data about radius of atoms base on protein type and element name.
 * Type is protein name.
 * ElementRadius is atom name.
 * Raidus is radius of atom.
 */
public class RadiusInfo
{
  

    public string Type { get; set; }
    public string ElementRadius { get; set; }
    public float Raidus { get; set; }

    public RadiusInfo(string type, string elementRadius, float radius)
    {
        this.Type = type;
        this.ElementRadius = elementRadius;
        this.Raidus = radius;
    }
}
