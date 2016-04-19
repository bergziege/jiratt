﻿using DryIoc;

namespace JiraReleaseNoteCreator {
    public class AppContext {
        private static readonly AppContext instance = new AppContext();

        public static AppContext Instance {
            get { return instance; }
        }

        static AppContext() {
        }

        private AppContext() {

        }

        public IContainer Container { get; set; }
    }
}