ShootingGame2
=============

玩法说明
---------

2D飞行射击游戏，使用左右方向键制我方飞船，躲避陨石。使用空格键船发出子弹摧毁敌人并得分。游戏目的获得500分（击中5个陨石），有3个生命，这意味着如果被飞船被撞击次数过多游戏将会结束。

技术细节
--------
基于Unity3d 4.3.4f1，使用最原始的GUI制作简单的界面按钮。用简单的物理碰撞处理子弹、敌人、主角之间的撞击，并实现了简单的射击音效，爆炸音效和特效。飞船飞行的效果使用两个平面循环模拟。

同[ShootingGame](https://github.com/mingchaoyan/ShootingGame/blob/master/GameShots/begin.png)区别
-----------------
1. ShootingGame的主摄像头使用Perspectivet投影方式，ShootingGame2的主摄像头使用Orthographic投影方式

2. ShootingGame的爆炸效果通过外部特效，ShootingGame2的爆炸效果使用U3D原生粒子系统   

游戏展示
--------
- 开始界面：
![image](https://github.com/mingchaoyan/ShootingGame2/blob/master/GameShots/Start.png)
- 游戏界面：
![image](https://github.com/mingchaoyan/ShootingGame2/blob/master/GameShots/Playing.png)
- 胜利结束：
![image](https://github.com/mingchaoyan/ShootingGame2/blob/master/GameShots/StopWin.png)
- 失败结束：
![image](https://github.com/mingchaoyan/ShootingGame2/blob/master/GameShots/StopLose.png)
