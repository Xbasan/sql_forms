# Указываем модификатор (Mod4 — это клавиша Super/Win)
set $mod Mod4

# Запуск терминала
bindsym $mod+Return exec alacritty

# Перезапуск i3 (без выхода из сессии)
bindsym $mod+Shift+r restart

# Выход из i3
bindsym $mod+Shift+e exec "i3-msg exit"

# Закрытие окна
bindsym $mod+Shift+q kill

# Переключение фокуса между окнами (Vim-стиль)
bindsym $mod+h focus left
bindsym $mod+l focus right
bindsym $mod+j focus down
bindsym $mod+k focus up

# Перемещение окон
bindsym $mod+Shift+h move left
bindsym $mod+Shift+l move right
bindsym $mod+Shift+j move down
bindsym $mod+Shift+k move up

# Изменение размеров окон (используем режим "resize")
mode "resize" {
    bindsym h resize shrink width 10 px
    bindsym l resize grow width 10 px
    bindsym j resize shrink height 10 px
    bindsym k resize grow height 10 px
    bindsym Escape mode "default"
}
bindsym $mod+r mode "resize"

# Запуск dmenu для открытия приложений
bindsym $mod+d exec dmenu_run

# Переключение рабочих столов (1-9)
bindsym $mod+1 workspace 1
bindsym $mod+2 workspace 2
bindsym $mod+3 workspace 3
bindsym $mod+4 workspace 4
bindsym $mod+5 workspace 5
bindsym $mod+6 workspace 6
bindsym $mod+7 workspace 7
bindsym $mod+8 workspace 8
bindsym $mod+9 workspace 9

# Перемещение окон между рабочими столами
bindsym $mod+Shift+1 move container to workspace 1
bindsym $mod+Shift+2 move container to workspace 2
bindsym $mod+Shift+3 move container to workspace 3
bindsym $mod+Shift+4 move container to workspace 4
bindsym $mod+Shift+5 move container to workspace 5
bindsym $mod+Shift+6 move container to workspace 6
bindsym $mod+Shift+7 move container to workspace 7
bindsym $mod+Shift+8 move container to workspace 8
bindsym $mod+Shift+9 move container to workspace 9

# Полноэкранный режим окна
bindsym $mod+f fullscreen toggle

# Плиточный и табличный режимы
bindsym $mod+e layout toggle split
bindsym $mod+s layout stacking
bindsym $mod+w layout tabbed

# Блокировка экрана (если установлен i3lock)
bindsym $mod+Shift+x exec i3lock -c 000000

# Выключение, перезагрузка, сон
bindsym $mod+Shift+s exec systemctl suspend
bindsym $mod+Shift+p exec systemctl poweroff
bindsym $mod+Shift+r exec systemctl reboot

# Переключение между плавающими и плиточными окнами
bindsym $mod+Shift+space floating toggle

# Запуск rofi (более удобная альтернатива dmenu)
bindsym $mod+p exec rofi -show drun

# Включение режимов разметки (разделение окон)
bindsym $mod+v split v
bindsym $mod+h split h

# Автозапуск программ (пример)
exec --no-startup-id nm-applet
exec --no-startup-id picom --config ~/.config/picom.conf
exec --no-startup-id feh --bg-scale ~/Pictures/wallpaper.jpg
