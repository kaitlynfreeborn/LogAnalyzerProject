using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Threading;
using Microsoft.Win32;
using System.Collections;

namespace LogAnalysis
{
    /// <summary>
    /// Interaction logic for Data.xaml
    /// </summary>
    public partial class Data : Window
    {
        public Data()
        {
            InitializeComponent();

            try
            {
                string myLogName = "MyNewLog";
                // Check if the source exists.
                if (!EventLog.SourceExists("Security"))
                {
                    // Create the source.
                    // An event log source should not be created and immediately used.
                    // There is a latency time to enable the source, it should be created
                    // prior to executing the application that uses the source.
                    // Execute this sample a second time to use the new source.
                    EventLog.CreateEventSource("Security", myLogName);
                    Console.WriteLine("Creating EventSource");
                    Console.WriteLine("Exiting, execute the application a second time to use the source.");
                    // The source is created.  Exit the application to allow it to be registered.
                    return;
                }
                else
                {
                    // Get the EventLog associated if the source exists.
                    myLogName = EventLog.LogNameFromSourceName("Security", ".");
                }

                // Create an EventLog instance and assign its source.
                EventLog myEventLog2 = new EventLog();
                myEventLog2.Source = "Security";
                // Write an informational entry to the event log.
                myEventLog2.WriteEntry("Successfully created a new Entry in the Log");
                myEventLog2.Close();
                // Create a new EventLog object.
                EventLog myEventLog1 = new EventLog();
                myEventLog1.Log = myLogName;

                // Obtain the Log Entries of "MyNewLog".
                EventLogEntryCollection myEventLogEntryCollection =
                   myEventLog1.Entries;
                myEventLog1.Close();
                Console.WriteLine("The number of entries in 'MyNewLog' = "
                   + myEventLogEntryCollection.Count);

                // Display the 'Message' property of EventLogEntry.
                for (int i = 0; i < myEventLogEntryCollection.Count; i++)
                {
                    Console.WriteLine("The Message of the EventLog is :"
                       + myEventLogEntryCollection[i].Message);
                }

                // Copy the EventLog entries to Array of type EventLogEntry.
                EventLogEntry[] myEventLogEntryArray =
                   new EventLogEntry[myEventLogEntryCollection.Count];
                myEventLogEntryCollection.CopyTo(myEventLogEntryArray, 0);
                IEnumerator myEnumerator = myEventLogEntryArray.GetEnumerator();
                while (myEnumerator.MoveNext())
                {
                    EventLogEntry myEventLogEntry = (EventLogEntry)myEnumerator.Current;
                    Console.WriteLine("The LocalTime the Event is generated is "
                       + myEventLogEntry.TimeGenerated);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception:{0}", e.Message);
                
            }
        }
    }
}

