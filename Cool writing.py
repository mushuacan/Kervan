import time
import random

def writeCool(written="hata#13"):
    for letter in written:
        print(letter, end='')
        time.sleep(random.uniform(0.08, 0.001))

writeCool("This program will be otomatikli closed")
writeCool("\n\nPlease feel free to wait until it ends.")
writeCool("\nThis is not going anywhere. I just wanted to write this.")
writeCool("\n\nIf you open this with python IDLE, writings will apair cool.")
writeCool("\nBut if you open directly (çift tık ile) it'll just throw you sentense like löpçük diye.")
writeCool("\nThanks for reading this")
print(".")
time.sleep(3)
writeCool("\n\n\n\nBye")
print("!")
time.sleep(1)
print("\n\n#buraya gizli bir şey yazarsam bir sonraki karede program kapanacağından gözükmez. Ama pythondan açılırsa gözükmeye devam eder.")
#Üsttekini bilerek içinde yazdım.
