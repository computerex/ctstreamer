from time import sleep
from datetime import datetime
import urllib2

#seconds
SLEEP_TIME = 60
SECRET = "8df25ed30e328c34841f5e64b0c2d11f"

while 1==1:
		urllib2.urlopen("http://127.0.0.1/housekeeping.php?secret="+SECRET)
		print datetime.now().time()
		sleep(SLEEP_TIME)
