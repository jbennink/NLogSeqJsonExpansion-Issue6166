# NLogSeqJsonExpansion-Issue6166

This is a repro of an Issue I encountered in our software after upgrading from NLog 6.0.7 to NLog 6.1.0.

We are logggin API payload ising the `{@Object}` syntax which worked fine until 6.1.0. After close inspection and removing stuff I found out
that setting the Properties dictionary on a logger instance results in this issue. 

Just removing line 14 from Program.cs makes it work. But we set Properties on the logger after creating it for Customer, Module and other fields 
that do not need to show in the Logline but need to be logged for debugging.
