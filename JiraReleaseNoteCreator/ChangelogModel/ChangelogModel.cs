using System;
using System.Collections.Generic;
using System.Text;

namespace JiraReleaseNoteCreator.ChangelogModel {
    public class ChangelogModel {
        private IList<VersionModel> _versions = new List<VersionModel>();

        public IList<VersionModel> Versions {
            get { return _versions; }
            set { _versions = value; }
        }

        /// <summary>
        /// Gibt eine Zeichenfolge zurück, die das aktuelle Objekt darstellt.
        /// </summary>
        /// <returns>
        /// Eine Zeichenfolge, die das aktuelle Objekt darstellt.
        /// </returns>
        public override string ToString() {
            StringBuilder builder = new StringBuilder();
            foreach (VersionModel versionModel in Versions) {
                builder.Append(versionModel);
            }
            return builder.ToString();
        }
    }
}