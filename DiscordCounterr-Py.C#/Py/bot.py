from selenium import webdriver
from selenium.webdriver.common.keys import Keys
from selenium.webdriver.common.by import By
from selenium.webdriver.support import expected_conditions as EC
import time
import datetime
import random

start_time = datetime.datetime.now()

count = 0
last_message = 0
last_count = 0

next_message_number = 0

try:
    driver = webdriver.Chrome('/path/to/chromedriver.exe')
    driver.get('https://discord.com/login')
    time.sleep(1)

    username_field = driver.find_element(By.NAME, "email")
    password_field = driver.find_element(By.NAME, "password")

    username_field.send_keys('iwan28tt@gmail.com')
    password_field.send_keys('IwanSilas28@')

    password_field.send_keys(Keys.RETURN)
    time.sleep(1)

    last_count = 0

    driver.get('https://discord.com/channels/1066547396726771752/1066547510312702063')
    time.sleep(10)

    message_box = driver.find_element(By.XPATH, "//div[contains(@class,'inner')]/div[contains(@class,'textArea')]//div[@role='textbox']")
    last_message = 0
    count = 0

    time_elapsed = datetime.timedelta(0)

    while True:
        try:
            warning_elements = driver.find_elements(By.XPATH, "//img[contains(@src, '/assets/2896') and @class='emoji']//ancestor::li//div[contains(@class, 'messageContent')]")
            warning_id = None
            if len(warning_elements) > 0:
                warning_element = warning_elements[-1]
                warning_id = warning_element.get_attribute('id')
                warning_id = warning_id.replace('message-content-', '')
                warning_id = int(warning_id)

            alle_vinkjes = driver.find_elements(By.XPATH, "//img[(contains(@src, '/assets/86c16c3') or contains(@src, '/assets/212e30e') or contains(@src, '/assets/db009c8') or contains(@src, '/assets/d23c2dd')) and @class='emoji']//ancestor::li//div[contains(@class, 'messageContent')]")
            if len(alle_vinkjes) == 0:
                print('niks gevonden')
            else:
                laatste_vinkje = alle_vinkjes[-1]
                laatste_vinkje_id = laatste_vinkje.get_attribute('id')
                laatste_vinkje_id = laatste_vinkje_id.replace('message-content-', '')
                laatste_vinkje_id = int(laatste_vinkje_id)

                if warning_id is not None and warning_id > laatste_vinkje_id:
                    print("laatste was fout")
                    last_message = 0
                else:
                    print("Laatste: " + laatste_vinkje.text)
                    gebruiker = laatste_vinkje.find_element(By.XPATH, "./..//span[contains(@class, 'username')]").text
                    print(gebruiker)
                if gebruiker != "IwanVFX":
                    message_id = laatste_vinkje.text
                    next_message_number = str(int(message_id) + 1)
                if int(next_message_number) >= int(last_message) + 2:
                    message_box.send_keys(next_message_number)
                    message_box.send_keys(Keys.RETURN)
                    last_message = int(next_message_number)
                    count += 1
                    if count % 10 == 0:
                        random_delay = random.uniform(0, 7.5)
                    else:
                        random_delay = random.uniform(0, 2.25)
                    time.sleep(random_delay)

                    if count % 100 == 0:
                        current_time = datetime.datetime.now()
                        time_elapsed = current_time - start_time
                        count_since_last = count - last_count
                        last_count = count
                        with open("stats.txt", "a") as f:
                            f.write(f"Count: {count}, Time Elapsed: {time_elapsed}, Count Since Last: {count_since_last}\n")
                    else:
                        time.sleep(0.5)

        except Exception as e:
            print("Exception occurred: ", e)
            continue

except Exception as e:
    print("Exception occurred: ", e)

finally:
    driver.quit()