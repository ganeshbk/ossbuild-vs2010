:: This script is used to view GraphViz .dot files.
:: You will need to install GraphViz first: http://www.graphviz.org/Download_windows.php
:: Then just select 'Open with...' or drag a .dot file over the .bat to see it.

dot -Tpng %1 > %~n1.png
start %~n1.png