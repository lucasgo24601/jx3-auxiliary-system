# 簡介：
基於 Visual Studio 進行開發，主要是練習程式用的，皆附有Demo，但JX3_AuxiliarySystem 會依賴於遊戲，而台灣伺服器已關閉，故以下皆為示意圖。

# JX3_AuxiliarySystem：
網路遊戲 - 劍俠情緣 3 online的輔助程式，該遊戲有個很有趣的玩法，是由25個玩家組成的隊伍，發揮各門派的特色一起對抗 BOSS。 而對抗過程中需要隊長進行調度，像是02:30秒 Boss 會使出一招，需要某個職業打出特殊技能才能幫大家度過這次災難。

1. 所以身為隊長必須根據各種場景來提醒，於是該程式會自動判斷 時間、團隊血量、Boss 血量、Boss 對話等等 進行圖像處理，以此得到對應的數據，之後給予倒數時間條提示對應的行為。
![](https://i.imgur.com/nSYkJJX.jpg)
2. 該遊戲有個科舉活動，於周末舉辦出題答題的活動，而科舉題目多半為文言文或歷史人物傳記，深澀難懂，所以多數人都是利用網路上的文章搜尋這題答案，此輔助程式可以根據資料庫和影像處理直接提示該題答案為何，無須在上網搜尋答案。
![](https://i.imgur.com/3ZH3fvQ.png)
1.  該遊戲有個神農日常，可以於特定地方採集藥材，而藥材採集通常都需要人工按下採集按鈕後進行採集，之後根據神農系統提示最近的草藥點在哪，之後自動尋路移動過去，該程式可以自動按下採集按鈕並且根據圖形處理點集自動尋路功能。(實作按鈕部分請參考 Keyboard Mouse Mange 程式)
2.  每個人的影像處裡資料庫都可採樣，並可以自動把資料庫至於雲端 ( 個人 MEGA，一天最多8GB上傳下載 )上，還可以選擇同步當前最新版所有人的資料庫集合。
![](https://i.imgur.com/vyifKoB.png)
