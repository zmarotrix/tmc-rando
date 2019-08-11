using MinishRandomizer.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinishRandomizer.Randomizer.Settings
{
    public class SettingsObject
    {

        /// <summary>
        /// Randomizes Shop Items into the item pool.
        /// </summary>
        public bool AddShopItems { get; set; }

        /// <summary>
        /// Randomizes Figurines into the item pool. This is an example.
        /// </summary>
        public bool AddFigurines { get; set; }


        private int _seed;
        public int Seed
        {
            get => _seed;
            set
            {
                _seed = value;
            }
        }

        private int[] BuildSettingsBytes()
        {
            int[] parts = new int[2];

            if (AddShopItems) { parts[0] += 1; };
            if (AddFigurines) { parts[0] += 2; };

            parts[1] = 0; // Future Proofing

            return parts;
        }





        private string EncodeSettings()
        {
            var partsEncoded = BuildSettingsBytes()
                .Select(p => Base36Utils.Encode(p))
                .ToArray();

            return string.Join("-", partsEncoded); // Future Proofing
        }


        public override string ToString()
        {
            return EncodeSettings();
        }
    }
}
