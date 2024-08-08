from gpiozero import LED, Button
from time import sleep
import requests
import mysql.connector as mc




#A=18,B=23,C=24,D=12,E=16,F=20,G=21
sega = LED(24)
segb = LED(25)
segc = LED(16)
segd = LED(20)
sege = LED(21)
segf = LED(23)
segg = LED(18)


#btn_activate
btn = Button(5)

#Alarm zones
zone1 = Button(13)
zone2 = Button(19)
zone3 = Button(26)
zone4 = Button(6)




def show0():
    #0
    sega.off()
    segb.off()
    segc.off()
    segd.off()
    sege.off()
    segf.off()
    segg.on()


def show1():
    #1
    sega.on()
    segb.off()
    segc.off()
    segd.on()
    sege.on()
    segf.on()
    segg.on()


def show2():
    #2
    sega.off()
    segb.off()
    segc.on()
    segd.off()
    sege.off()
    segf.on()
    segg.off()  
    

def show3():
    #3
    sega.off()
    segb.off()
    segc.off()
    segd.off()
    sege.on()
    segf.on()
    segg.off() 


def show4():
    #4
    sega.on()
    segb.off()
    segc.off()
    segd.on()
    sege.on()
    segf.off()
    segg.off() 


def show5():
    #5
    sega.off()
    segb.on()
    segc.off()
    segd.off()
    sege.on()
    segf.off()
    segg.off()  
 


def show6():
    #6
    sega.off()
    segb.on()
    segc.off()
    segd.off()
    sege.off()
    segf.off()
    segg.off() 


def show7():
    #7
    sega.off()
    segb.off()
    segc.off()
    segd.on()
    sege.on()
    segf.on()
    segg.on()     



def show8():
    #8
    sega.off()
    segb.off()
    segc.off()
    segd.off()
    sege.off()
    segf.off()
    segg.off()  


def show9():
    #9
    sega.off()
    segb.off()
    segc.off()
    segd.on()
    sege.on()
    segf.off()
    segg.off()    



def showA():
    #A
    sega.off()
    segb.off()
    segc.off()
    segd.on()
    sege.off()
    segf.off()
    segg.off()

def cout_up():
    #0
    show0
    sleep(1)

    #1
    show1()    
    sleep(1)

    #2
    show2() 
    sleep(1)

    #3
    show3()  
    sleep(1)
        
    #4
    show4()
    sleep(1)

    #5
    show5()
    sleep(1)

    #6
    show6() 
    sleep(1)

    #7
    show7() 
    sleep(1)


    #8
    show8()  
    sleep(1)


    #9
    show9()
    sleep(1)



def cout_down():
    #9
    show9    
    sleep(1)

    #8
    show8()  
    sleep(1)

    #7
    show7()   
    sleep(1)

    #6
    show6()  
    sleep(1)

    #5
    show5() 
    sleep(1)

    #4
    show4()  
    sleep(1)

    #3
    show3()    
    sleep(1)

    #2
    show2()  
    sleep(1)

    #1
    show1()    
    sleep(1)
    
    #0
    show0()
    sleep(1)


#Interface.main()
show0()
def connection():
        try:

           conn=mc.connect(host='10.1.10.74',database='alarm_systeme',user='root',password='123')
           #print(conn)
           return conn
        except mc.Error as e:
           print(e)

        
        
def con():

    try:
        conn=connection()
        cursor=conn.cursor()
        req='select * from etat_zones'
        cursor.execute(req)
        mylst=cursor.fetchall()

        for i in mylst:
            Zone1_state=i[0]
            Zone2_state =i[1]
            Zone3_state =i[2]
            Zone4_state =i[3]
            Status_state = i[4] 
        return Zone1_state,Zone2_state,Zone3_state,Zone4_state,Status_state  

    except mc.Error as e:
        print(e)

    finally:
        if(conn.is_connected()):
            cursor.close()
            conn.close()
   
def send_data_to_server(Zone1_state,Zone2_state,Zone3_state,Zone4_state,Status_state):
        
    data={"Zone1":Zone1_state, "Zone2":Zone2_state, "Zone3":Zone3_state, "Zone4":Zone4_state, "Status":Status_state}
    resp = requests.post('http://10.1.10.74/dashboard/Poc/Api.php', params=data)
    print(f'Response:{resp.status_code}__{data}')
    

def connection():
    try:

       conn=mc.connect(host='10.1.10.74',database='alarm_systeme',user='root',password='123')
       #print(conn)
       return conn
    except mc.Error as e:
        print(e)

        
        
def con():

    try:
        conn=connection()
        cursor=conn.cursor()
        req='select * from etat_zones'
        cursor.execute(req)
        mylst=cursor.fetchall()

        for i in mylst:
            Zone1_state=i[0]
            Zone2_state =i[1]
            Zone3_state =i[2]
            Zone4_state =i[3]
            Status_state = i[4] 
        return Zone1_state,Zone2_state,Zone3_state,Zone4_state,Status_state  

    except mc.Error as e:
        print(e)

    finally:
        if(conn.is_connected()):
            cursor.close()
            conn.close()
   
def send_data_to_server(Zone1_state,Zone2_state,Zone3_state,Zone4_state,Status_state):
        
    data={"Zone1":Zone1_state, "Zone2":Zone2_state, "Zone3":Zone3_state, "Zone4":Zone4_state, "Status":Status_state}
    resp = requests.post('http://10.1.10.74/dashboard/Poc/Api.php', params=data)
    return resp
    #print(f'Response:{resp.status_code}__{data}')
    


resp=''
while True:
    
    #print('Ca  marche 1')
    Zone1_state,Zone2_state,Zone3_state,Zone4_state,Status_state=con()
    print(Zone1_state,Zone2_state,Zone3_state,Zone4_state,Status_state)
    
    if (Status_state == 'Deactivate' or   Status_state == 'deactivate') and btn.is_pressed:
        Status_state = 'Activate'
        cout_up()
        showA()
        
        resp=send_data_to_server(Zone1_state,Zone2_state,Zone3_state,Zone4_state,Status_state)
    elif(Status_state == 'Activate' or Status_state == 'activate' ) and btn.is_pressed:
        Status_state = 'Deactivate'
        cout_down()
        show0()
        
        resp=send_data_to_server(Zone1_state,Zone2_state,Zone3_state,Zone4_state,Status_state)

    if (Status_state == 'Activate' or Status_state == 'activate'):
        if zone1.is_pressed:
            show1()
            if (Zone1_state=='Off' or Zone1_state=='off'):
                Zone1_state='On'
                resp=send_data_to_server(Zone1_state,Zone2_state,Zone3_state,Zone4_state,Status_state)
            elif (Zone1_state=='On'or Zone1_state=='on'):
                Zone1_state='Off'
                resp=send_data_to_server(Zone1_state,Zone2_state,Zone3_state,Zone4_state,Status_state)
            
        elif zone2.is_pressed:
            show2()
            if (Zone2_state=='Off'or Zone2_state=='off'):
                Zone2_state='On'
                resp=send_data_to_server(Zone1_state,Zone2_state,Zone3_state,Zone4_state,Status_state)
            elif (Zone2_state=='On' or Zone2_state=='on'):
                Zone2_state='Off'
                resp=send_data_to_server(Zone1_state,Zone2_state,Zone3_state,Zone4_state,Status_state)
        elif zone3.is_pressed:
            show3()
            if (Zone3_state=='Off' or Zone3_state=='off'):
                Zone3_state='On'
                resp=send_data_to_server(Zone1_state,Zone2_state,Zone3_state,Zone4_state,Status_state)
            elif (Zone3_state=='On' or Zone3_state=='on'):
                Zone3_state='Off'
                resp=send_data_to_server(Zone1_state,Zone2_state,Zone3_state,Zone4_state,Status_state)
        elif zone4.is_pressed:
            show4()
            if (Zone4_state=='Off' or Zone4_state=='off'):
                Zone4_state='On'
                resp=send_data_to_server(Zone1_state,Zone2_state,Zone3_state,Zone4_state,Status_state)
            elif (Zone4_state=='On' or Zone4_state=='on'):
                Zone4_state='Off'
                resp=send_data_to_server(Zone1_state,Zone2_state,Zone3_state,Zone4_state,Status_state)
    print(f'Response:{resp}--{Zone1_state,Zone2_state,Zone3_state,Zone4_state,Status_state}')

