using System.Collections.Generic;

namespace ShopTool.Comm
{
    public static class ComboUtil
    {
        public static List<ConnectedComboInfo> GetDatatSourceForCategory()
        {
            List<ConnectedComboInfo> list = new List<ConnectedComboInfo>();

            ConnectedComboInfo c0_0_0 = new ConnectedComboInfo();
            c0_0_0.ID = "";
            c0_0_0.Name = "カテゴリを選択する";
            list.Add(c0_0_0);

            ConnectedComboInfo c1_0_0 = new ConnectedComboInfo();
            c1_0_0.ID = "";
            c1_0_0.Name = "ファッション";
            list.Add(c1_0_0);

            ConnectedComboInfo c1_1_0 = new ConnectedComboInfo();
            c1_1_0.ID = "1";
            c1_1_0.Name = "トップス";
            c1_0_0.Children.Add(c1_1_0);

            ConnectedComboInfo c1_2_0 = new ConnectedComboInfo();
            c1_2_0.ID = "2";
            c1_2_0.Name = "アウター";
            c1_0_0.Children.Add(c1_2_0);

            ConnectedComboInfo c1_3_0 = new ConnectedComboInfo();
            c1_3_0.ID = "3";
            c1_3_0.Name = "ワンピース";
            //c1_0_0.Children.Add(c1_3_0);

            ConnectedComboInfo c1_4_0 = new ConnectedComboInfo();
            c1_4_0.ID = "4";
            c1_4_0.Name = "シューズ";
            c1_0_0.Children.Add(c1_4_0);

            ConnectedComboInfo c1_5_0 = new ConnectedComboInfo();
            c1_5_0.ID = "5";
            c1_5_0.Name = "パンツ";
            c1_0_0.Children.Add(c1_5_0);

            ConnectedComboInfo c1_6_0 = new ConnectedComboInfo();
            c1_6_0.ID = "6";
            c1_6_0.Name = "スカート";
            //c1_0_0.Children.Add(c1_6_0);

            ConnectedComboInfo c1_7_0 = new ConnectedComboInfo();
            c1_7_0.ID = "7";
            c1_7_0.Name = "セット / コーデ";
            //c1_0_0.Children.Add(c1_7_0);

            ConnectedComboInfo c1_8_0 = new ConnectedComboInfo();
            c1_8_0.ID = "8";
            c1_8_0.Name = "バッグ";
            c1_0_0.Children.Add(c1_8_0);

            ConnectedComboInfo c1_9_0 = new ConnectedComboInfo();
            c1_9_0.ID = "9";
            c1_9_0.Name = "アクセサリー";
            //c1_0_0.Children.Add(c1_9_0);

            ConnectedComboInfo c1_10_0 = new ConnectedComboInfo();
            c1_10_0.ID = "10";
            c1_10_0.Name = "ヘアアクセサリー";
            //c1_0_0.Children.Add(c1_10_0);

            ConnectedComboInfo c1_11_0 = new ConnectedComboInfo();
            c1_11_0.ID = "11";
            c1_11_0.Name = "ルームウェア / パジャマ";
            //c1_0_0.Children.Add(c1_11_0);

            ConnectedComboInfo c1_12_0 = new ConnectedComboInfo();
            c1_12_0.ID = "12";
            c1_12_0.Name = "レッグウェア";
            //c1_0_0.Children.Add(c1_12_0);

            ConnectedComboInfo c1_13_0 = new ConnectedComboInfo();
            c1_13_0.ID = "13";
            c1_13_0.Name = "帽子";
            c1_0_0.Children.Add(c1_13_0);

            ConnectedComboInfo c1_14_0 = new ConnectedComboInfo();
            c1_14_0.ID = "14";
            c1_14_0.Name = "ハンドメイド";
            //c1_0_0.Children.Add(c1_14_0);

            ConnectedComboInfo c1_15_0 = new ConnectedComboInfo();
            c1_15_0.ID = "15";
            c1_15_0.Name = "小物";
            c1_0_0.Children.Add(c1_15_0);

            ConnectedComboInfo c1_16_0 = new ConnectedComboInfo();
            c1_16_0.ID = "16";
            c1_16_0.Name = "ウィッグ / エクステ";
            //c1_0_0.Children.Add(c1_16_0);

            ConnectedComboInfo c1_17_0 = new ConnectedComboInfo();
            c1_17_0.ID = "17";
            c1_17_0.Name = "コスメ / ネイル";
            //c1_0_0.Children.Add(c1_17_0);

            ConnectedComboInfo c1_18_0 = new ConnectedComboInfo();
            c1_18_0.ID = "18";
            c1_18_0.Name = "水着 / 浴衣";
            //c1_0_0.Children.Add(c1_18_0);

            ConnectedComboInfo c1_19_0 = new ConnectedComboInfo();
            c1_19_0.ID = "19";
            c1_19_0.Name = "フォーマル / ドレス";
            //c1_0_0.Children.Add(c1_19_0);

            ConnectedComboInfo c1_1_1 = new ConnectedComboInfo();
            c1_1_1.ID = "0101";
            c1_1_1.Name = "Tシャツ(半袖/ノースリーブ)";
            c1_1_0.Children.Add(c1_1_1);
            ConnectedComboInfo c1_1_2 = new ConnectedComboInfo();
            c1_1_2.ID = "0102";
            c1_1_2.Name = "Tシャツ(長袖 / 五丈 / 七丈)";
            c1_1_0.Children.Add(c1_1_2);
            //ConnectedComboInfo c1_1_3 = new ConnectedComboInfo();
            //c1_1_3.ID = "0103";
            //c1_1_3.Name = "カットソー(半袖 / ノースリーブ)";
            //c1_1_0.Children.Add(c1_1_3);
            //ConnectedComboInfo c1_1_4 = new ConnectedComboInfo();
            //c1_1_4.ID = "0104";
            //c1_1_4.Name = "カットソー(長袖 / 五丈 / 七丈)";
            //c1_1_0.Children.Add(c1_1_4);
            //ConnectedComboInfo c1_1_5 = new ConnectedComboInfo();
            //c1_1_5.ID = "0105";
            //c1_1_5.Name = "シャツ / ブラウス(半袖 / ノースリーブ)";
            //c1_1_0.Children.Add(c1_1_5);
            //ConnectedComboInfo c1_1_6 = new ConnectedComboInfo();
            //c1_1_6.ID = "0106";
            //c1_1_6.Name = "シャツ / ブラウス(長袖 / 五丈 / 七丈)";
            //c1_1_0.Children.Add(c1_1_6);
            ConnectedComboInfo c1_1_7 = new ConnectedComboInfo();
            c1_1_7.ID = "0107";
            c1_1_7.Name = "ポロシャツ";
            c1_1_0.Children.Add(c1_1_7);
            ConnectedComboInfo c1_1_8 = new ConnectedComboInfo();
            c1_1_8.ID = "0108";
            c1_1_8.Name = "ニット / セーター";
            c1_1_0.Children.Add(c1_1_8);
            ConnectedComboInfo c1_1_9 = new ConnectedComboInfo();
            c1_1_9.ID = "0109";
            c1_1_9.Name = "パーカー";
            c1_1_0.Children.Add(c1_1_9);
            ConnectedComboInfo c1_1_10 = new ConnectedComboInfo();
            c1_1_10.ID = "0110";
            c1_1_10.Name = "カーディガン";
            c1_1_0.Children.Add(c1_1_10);
            ConnectedComboInfo c1_1_11 = new ConnectedComboInfo();
            c1_1_11.ID = "0111";
            c1_1_11.Name = "トレーナー / スウェット";
            c1_1_0.Children.Add(c1_1_11);
            //ConnectedComboInfo c1_1_12 = new ConnectedComboInfo();
            //c1_1_12.ID = "0112";
            //c1_1_12.Name = "キャミソール";
            //c1_1_0.Children.Add(c1_1_12);
            //ConnectedComboInfo c1_1_13 = new ConnectedComboInfo();
            //c1_1_13.ID = "0113";
            //c1_1_13.Name = "タンクトップ";
            //c1_1_0.Children.Add(c1_1_13);
            //ConnectedComboInfo c1_1_14 = new ConnectedComboInfo();
            //c1_1_14.ID = "0114";
            //c1_1_14.Name = "ベアトップ / チューブトップ";
            //c1_1_0.Children.Add(c1_1_14);
            //ConnectedComboInfo c1_1_15 = new ConnectedComboInfo();
            //c1_1_15.ID = "0115";
            //c1_1_15.Name = "ホルタ―ネック";
            //c1_1_0.Children.Add(c1_1_15);
            //ConnectedComboInfo c1_1_16 = new ConnectedComboInfo();
            //c1_1_16.ID = "0116";
            //c1_1_16.Name = "チュニック";
            //c1_1_0.Children.Add(c1_1_16);
            //ConnectedComboInfo c1_1_17 = new ConnectedComboInfo();
            //c1_1_17.ID = "0117";
            //c1_1_17.Name = "ベスト / ジレ";
            //c1_1_0.Children.Add(c1_1_17);
            //ConnectedComboInfo c1_1_18 = new ConnectedComboInfo();
            //c1_1_18.ID = "0118";
            //c1_1_18.Name = "アンサンブル";
            //c1_1_0.Children.Add(c1_1_18);
            //ConnectedComboInfo c1_1_19 = new ConnectedComboInfo();
            //c1_1_19.ID = "0119";
            //c1_1_19.Name = "ボレロ";
            //c1_1_0.Children.Add(c1_1_19);

            //ConnectedComboInfo c1_2_1 = new ConnectedComboInfo();
            //c1_2_1.ID = "0201";
            //c1_2_1.Name = "テーラードジャケット";
            //c1_2_0.Children.Add(c1_2_1);
            //ConnectedComboInfo c1_2_2 = new ConnectedComboInfo();
            //c1_2_2.ID = "0202";
            //c1_2_2.Name = "ライダースジャケット";
            //c1_2_0.Children.Add(c1_2_2);
            ConnectedComboInfo c1_2_3 = new ConnectedComboInfo();
            c1_2_3.ID = "0203";
            c1_2_3.Name = "Gジャン / デニムジャケット";
            c1_2_0.Children.Add(c1_2_3);
            ConnectedComboInfo c1_2_4 = new ConnectedComboInfo();
            c1_2_4.ID = "0204";
            c1_2_4.Name = "ミリタリージャケット";
            c1_2_0.Children.Add(c1_2_4);
            //ConnectedComboInfo c1_2_5 = new ConnectedComboInfo();
            //c1_2_5.ID = "0205";
            //c1_2_5.Name = "ノーカラージャケット";
            //c1_2_0.Children.Add(c1_2_5);
            ConnectedComboInfo c1_2_6 = new ConnectedComboInfo();
            c1_2_6.ID = "0206";
            c1_2_6.Name = "ダウンジャケット";
            c1_2_0.Children.Add(c1_2_6);
            //ConnectedComboInfo c1_2_7 = new ConnectedComboInfo();
            //c1_2_7.ID = "0207";
            //c1_2_7.Name = "ダウンベスト";
            //c1_2_0.Children.Add(c1_2_7);
            ConnectedComboInfo c1_2_8 = new ConnectedComboInfo();
            c1_2_8.ID = "0208";
            c1_2_8.Name = "ブルゾン";
            c1_2_0.Children.Add(c1_2_8);
            //ConnectedComboInfo c1_2_9 = new ConnectedComboInfo();
            //c1_2_9.ID = "0209";
            //c1_2_9.Name = "ポンチョ";
            //c1_2_0.Children.Add(c1_2_9);
            //ConnectedComboInfo c1_2_10 = new ConnectedComboInfo();
            //c1_2_10.ID = "0210";
            //c1_2_10.Name = "スタジャン";
            //c1_2_0.Children.Add(c1_2_10);
            //ConnectedComboInfo c1_2_11 = new ConnectedComboInfo();
            //c1_2_11.ID = "0211";
            //c1_2_11.Name = "スカジャン";
            //c1_2_0.Children.Add(c1_2_11);
            //ConnectedComboInfo c1_2_12 = new ConnectedComboInfo();
            //c1_2_12.ID = "0212";
            //c1_2_12.Name = "ロングコート";
            //c1_2_0.Children.Add(c1_2_12);
            //ConnectedComboInfo c1_2_13 = new ConnectedComboInfo();
            //c1_2_13.ID = "0213";
            //c1_2_13.Name = "トレンチコート";
            //c1_2_0.Children.Add(c1_2_13);
            //ConnectedComboInfo c1_2_14 = new ConnectedComboInfo();
            //c1_2_14.ID = "0214";
            //c1_2_14.Name = "ダッフルコート";
            //c1_2_0.Children.Add(c1_2_14);
            //ConnectedComboInfo c1_2_15 = new ConnectedComboInfo();
            //c1_2_15.ID = "0215";
            //c1_2_15.Name = "ピーコート";
            //c1_2_0.Children.Add(c1_2_15);
            //ConnectedComboInfo c1_2_16 = new ConnectedComboInfo();
            //c1_2_16.ID = "0216";
            //c1_2_16.Name = "モッズコート";
            //c1_2_0.Children.Add(c1_2_16);
            //ConnectedComboInfo c1_2_17 = new ConnectedComboInfo();
            //c1_2_17.ID = "0217";
            //c1_2_17.Name = "毛皮 / ファーコート";
            //c1_2_0.Children.Add(c1_2_17);
            //ConnectedComboInfo c1_2_18 = new ConnectedComboInfo();
            //c1_2_18.ID = "0218";
            //c1_2_18.Name = "スプリングコート";
            //c1_2_0.Children.Add(c1_2_18);
            //ConnectedComboInfo c1_2_19 = new ConnectedComboInfo();
            //c1_2_19.ID = "0219";
            //c1_2_19.Name = "ダウンコート";
            //c1_2_0.Children.Add(c1_2_19);

            ConnectedComboInfo c1_3_1 = new ConnectedComboInfo();
            c1_3_1.ID = "0301";
            c1_3_1.Name = "ミニワンピース";
            c1_3_0.Children.Add(c1_3_1);
            ConnectedComboInfo c1_3_2 = new ConnectedComboInfo();
            c1_3_2.ID = "0302";
            c1_3_2.Name = "ひざ丈ワンピース";
            c1_3_0.Children.Add(c1_3_2);
            ConnectedComboInfo c1_3_3 = new ConnectedComboInfo();
            c1_3_3.ID = "0303";
            c1_3_3.Name = "ロングワンピース";
            c1_3_0.Children.Add(c1_3_3);

            //ConnectedComboInfo c1_4_1 = new ConnectedComboInfo();
            //c1_4_1.ID = "0401";
            //c1_4_1.Name = "ハイヒール / パンプス";
            //c1_4_0.Children.Add(c1_4_1);
            //ConnectedComboInfo c1_4_2 = new ConnectedComboInfo();
            //c1_4_2.ID = "0402";
            //c1_4_2.Name = "ブーツ";
            //c1_4_0.Children.Add(c1_4_2);
            //ConnectedComboInfo c1_4_3 = new ConnectedComboInfo();
            //c1_4_3.ID = "0403";
            //c1_4_3.Name = "サンダル";
            //c1_4_0.Children.Add(c1_4_3);
            ConnectedComboInfo c1_4_4 = new ConnectedComboInfo();
            c1_4_4.ID = "0404";
            c1_4_4.Name = "スニーカー";
            c1_4_0.Children.Add(c1_4_4);
            //ConnectedComboInfo c1_4_5 = new ConnectedComboInfo();
            //c1_4_5.ID = "0405";
            //c1_4_5.Name = "ブーティ";
            //c1_4_0.Children.Add(c1_4_5);
            //ConnectedComboInfo c1_4_6 = new ConnectedComboInfo();
            //c1_4_6.ID = "0406";
            //c1_4_6.Name = "ミュール";
            //c1_4_0.Children.Add(c1_4_6);
            //ConnectedComboInfo c1_4_7 = new ConnectedComboInfo();
            //c1_4_7.ID = "0407";
            //c1_4_7.Name = "ローファー / 革靴";
            //c1_4_0.Children.Add(c1_4_7);
            //ConnectedComboInfo c1_4_8 = new ConnectedComboInfo();
            //c1_4_8.ID = "0408";
            //c1_4_8.Name = "ラバーブーツ / 長靴";
            //c1_4_0.Children.Add(c1_4_8);

            //ConnectedComboInfo c1_5_1 = new ConnectedComboInfo();
            //c1_5_1.ID = "0501";
            //c1_5_1.Name = "デニム / ジーンズ";
            //c1_5_0.Children.Add(c1_5_1);
            ConnectedComboInfo c1_5_2 = new ConnectedComboInfo();
            c1_5_2.ID = "0502";
            c1_5_2.Name = "ショートパンツ";
            c1_5_0.Children.Add(c1_5_2);
            ConnectedComboInfo c1_5_3 = new ConnectedComboInfo();
            c1_5_3.ID = "0503";
            c1_5_3.Name = "カジュアルパンツ";
            c1_5_0.Children.Add(c1_5_3);
            ConnectedComboInfo c1_5_4 = new ConnectedComboInfo();
            c1_5_4.ID = "0504";
            c1_5_4.Name = "ハーフパンツ";
            c1_5_0.Children.Add(c1_5_4);
            //ConnectedComboInfo c1_5_5 = new ConnectedComboInfo();
            //c1_5_5.ID = "0505";
            //c1_5_5.Name = "チノパン";
            //c1_5_0.Children.Add(c1_5_5);
            //ConnectedComboInfo c1_5_6 = new ConnectedComboInfo();
            //c1_5_6.ID = "0512";
            //c1_5_6.Name = "スキニーパンツ";
            //c1_5_0.Children.Add(c1_5_6);
            //ConnectedComboInfo c1_5_7 = new ConnectedComboInfo();
            //c1_5_7.ID = "0506";
            //c1_5_7.Name = "ワークパンツ / カーゴパンツ";
            //c1_5_0.Children.Add(c1_5_7);
            //ConnectedComboInfo c1_5_8 = new ConnectedComboInfo();
            //c1_5_8.ID = "0507";
            //c1_5_8.Name = "クロップドパンツ";
            //c1_5_0.Children.Add(c1_5_8);
            //ConnectedComboInfo c1_5_9 = new ConnectedComboInfo();
            //c1_5_9.ID = "0508";
            //c1_5_9.Name = "サロペット / オーバーオール";
            //c1_5_0.Children.Add(c1_5_9);
            //ConnectedComboInfo c1_5_10 = new ConnectedComboInfo();
            //c1_5_10.ID = "0509";
            //c1_5_10.Name = "オールインワン";
            //c1_5_0.Children.Add(c1_5_10);
            //ConnectedComboInfo c1_5_11 = new ConnectedComboInfo();
            //c1_5_11.ID = "0510";
            //c1_5_11.Name = "キュロット";
            //c1_5_0.Children.Add(c1_5_11);
            //ConnectedComboInfo c1_5_12 = new ConnectedComboInfo();
            //c1_5_12.ID = "0511";
            //c1_5_12.Name = "サルエルパンツ";
            //c1_5_0.Children.Add(c1_5_12);

            ConnectedComboInfo c1_6_1 = new ConnectedComboInfo();
            c1_6_1.ID = "0601";
            c1_6_1.Name = "ミニスカート";
            c1_6_0.Children.Add(c1_6_1);
            ConnectedComboInfo c1_6_2 = new ConnectedComboInfo();
            c1_6_2.ID = "0602";
            c1_6_2.Name = "ひざ丈スカート";
            c1_6_0.Children.Add(c1_6_2);
            ConnectedComboInfo c1_6_3 = new ConnectedComboInfo();
            c1_6_3.ID = "0603";
            c1_6_3.Name = "ロングスカート";
            c1_6_0.Children.Add(c1_6_3);
            ConnectedComboInfo c1_6_4 = new ConnectedComboInfo();
            c1_6_4.ID = "0604";
            c1_6_4.Name = "ジャンパースカート";
            c1_6_0.Children.Add(c1_6_4);

            ConnectedComboInfo c1_7_1 = new ConnectedComboInfo();
            c1_7_1.ID = "0701";
            c1_7_1.Name = "コーディネート";
            c1_7_0.Children.Add(c1_7_1);
            ConnectedComboInfo c1_7_2 = new ConnectedComboInfo();
            c1_7_2.ID = "0702";
            c1_7_2.Name = "まとめ売り";
            c1_7_0.Children.Add(c1_7_2);

            ConnectedComboInfo c1_8_1 = new ConnectedComboInfo();
            c1_8_1.ID = "0802";
            c1_8_1.Name = "ショルダーバッグ";
            c1_8_0.Children.Add(c1_8_1);
            //ConnectedComboInfo c1_8_2 = new ConnectedComboInfo();
            //c1_8_2.ID = "0803";
            //c1_8_2.Name = "ハンドバッグ";
            //c1_8_0.Children.Add(c1_8_2);
            ConnectedComboInfo c1_8_3 = new ConnectedComboInfo();
            c1_8_3.ID = "0804";
            c1_8_3.Name = "トートバッグ";
            c1_8_0.Children.Add(c1_8_3);
            ConnectedComboInfo c1_8_4 = new ConnectedComboInfo();
            c1_8_4.ID = "0805";
            c1_8_4.Name = "リュック / バックパック";
            c1_8_0.Children.Add(c1_8_4);
            //ConnectedComboInfo c1_8_5 = new ConnectedComboInfo();
            //c1_8_5.ID = "0806";
            //c1_8_5.Name = "ボストンバッグ";
            //c1_8_0.Children.Add(c1_8_5);
            //ConnectedComboInfo c1_8_6 = new ConnectedComboInfo();
            //c1_8_6.ID = "0807";
            //c1_8_6.Name = "クラッチバッグ";
            //c1_8_0.Children.Add(c1_8_6);
            //ConnectedComboInfo c1_8_7 = new ConnectedComboInfo();
            //c1_8_7.ID = "0808";
            //c1_8_7.Name = "エコバッグ";
            //c1_8_0.Children.Add(c1_8_7);
            //ConnectedComboInfo c1_8_8 = new ConnectedComboInfo();
            //c1_8_8.ID = "0809";
            //c1_8_8.Name = "ボディバッグ / ウエストポーチ";
            //c1_8_0.Children.Add(c1_8_8);
            //ConnectedComboInfo c1_8_9 = new ConnectedComboInfo();
            //c1_8_9.ID = "0810";
            //c1_8_9.Name = "メッセンジャーバッグ";
            //c1_8_0.Children.Add(c1_8_9);
            //ConnectedComboInfo c1_8_10 = new ConnectedComboInfo();
            //c1_8_10.ID = "0811";
            //c1_8_10.Name = "旅行用バッグ / キャリーバッグ";
            //c1_8_0.Children.Add(c1_8_10);
            //ConnectedComboInfo c1_8_11 = new ConnectedComboInfo();
            //c1_8_11.ID = "0812";
            //c1_8_11.Name = "ショップ袋";
            //c1_8_0.Children.Add(c1_8_11);

            ConnectedComboInfo c1_9_1 = new ConnectedComboInfo();
            c1_9_1.ID = "0901";
            c1_9_1.Name = "リング";
            c1_9_0.Children.Add(c1_9_1);
            ConnectedComboInfo c1_9_2 = new ConnectedComboInfo();
            c1_9_2.ID = "0902";
            c1_9_2.Name = "ネックレス";
            c1_9_0.Children.Add(c1_9_2);
            ConnectedComboInfo c1_9_3 = new ConnectedComboInfo();
            c1_9_3.ID = "0903";
            c1_9_3.Name = "ブレスレット / バングル";
            c1_9_0.Children.Add(c1_9_3);
            ConnectedComboInfo c1_9_4 = new ConnectedComboInfo();
            c1_9_4.ID = "0904";
            c1_9_4.Name = "ピアス";
            c1_9_0.Children.Add(c1_9_4);
            ConnectedComboInfo c1_9_5 = new ConnectedComboInfo();
            c1_9_5.ID = "0905";
            c1_9_5.Name = "イアリング";
            c1_9_0.Children.Add(c1_9_5);
            ConnectedComboInfo c1_9_6 = new ConnectedComboInfo();
            c1_9_6.ID = "0906";
            c1_9_6.Name = "ブローチ / コサージュ";
            c1_9_0.Children.Add(c1_9_6);
            ConnectedComboInfo c1_9_7 = new ConnectedComboInfo();
            c1_9_7.ID = "0907";
            c1_9_7.Name = "つけ襟";
            c1_9_0.Children.Add(c1_9_7);

            ConnectedComboInfo c1_10_1 = new ConnectedComboInfo();
            c1_10_1.ID = "1001";
            c1_10_1.Name = "ヘアバンド";
            c1_10_0.Children.Add(c1_10_1);
            ConnectedComboInfo c1_10_2 = new ConnectedComboInfo();
            c1_10_2.ID = "1002";
            c1_10_2.Name = "カチューシャ";
            c1_10_0.Children.Add(c1_10_2);
            ConnectedComboInfo c1_10_3 = new ConnectedComboInfo();
            c1_10_3.ID = "1003";
            c1_10_3.Name = "ヘアゴム / シュシュ";
            c1_10_0.Children.Add(c1_10_3);
            ConnectedComboInfo c1_10_4 = new ConnectedComboInfo();
            c1_10_4.ID = "1004";
            c1_10_4.Name = "ヘアピン";
            c1_10_0.Children.Add(c1_10_4);
            ConnectedComboInfo c1_10_5 = new ConnectedComboInfo();
            c1_10_5.ID = "1005";
            c1_10_5.Name = "コーム / バレッタ";
            c1_10_0.Children.Add(c1_10_5);

            ConnectedComboInfo c1_11_1 = new ConnectedComboInfo();
            c1_11_1.ID = "1101";
            c1_11_1.Name = "ルームウェア";
            c1_11_0.Children.Add(c1_11_1);
            ConnectedComboInfo c1_11_2 = new ConnectedComboInfo();
            c1_11_2.ID = "1102";
            c1_11_2.Name = "パジャマ";
            c1_11_0.Children.Add(c1_11_2);

            ConnectedComboInfo c1_12_1 = new ConnectedComboInfo();
            c1_12_1.ID = "1201";
            c1_12_1.Name = "ソックス";
            c1_12_0.Children.Add(c1_12_1);
            ConnectedComboInfo c1_12_2 = new ConnectedComboInfo();
            c1_12_2.ID = "1202";
            c1_12_2.Name = "レギンス / スパッツ";
            c1_12_0.Children.Add(c1_12_2);
            ConnectedComboInfo c1_12_3 = new ConnectedComboInfo();
            c1_12_3.ID = "1203";
            c1_12_3.Name = "タイツ / ストッキング";
            c1_12_0.Children.Add(c1_12_3);
            ConnectedComboInfo c1_12_4 = new ConnectedComboInfo();
            c1_12_4.ID = "1204";
            c1_12_4.Name = "レッグウォーマー"; 
            c1_12_0.Children.Add(c1_12_4);

            ConnectedComboInfo c1_13_1 = new ConnectedComboInfo();
            c1_13_1.ID = "1301";
            c1_13_1.Name = "ニットキャップ / ビーニー";
            c1_13_0.Children.Add(c1_13_1);
            //ConnectedComboInfo c1_13_2 = new ConnectedComboInfo();
            //c1_13_2.ID = "1302";
            //c1_13_2.Name = "ハット";
            //c1_13_0.Children.Add(c1_13_2);
            //ConnectedComboInfo c1_13_3 = new ConnectedComboInfo();
            //c1_13_3.ID = "1303";
            //c1_13_3.Name = "ハンチング / ベレー帽";
            //c1_13_0.Children.Add(c1_13_3);
            ConnectedComboInfo c1_13_4 = new ConnectedComboInfo();
            c1_13_4.ID = "1304";
            c1_13_4.Name = "キャップ";
            c1_13_0.Children.Add(c1_13_4);
            //ConnectedComboInfo c1_13_5 = new ConnectedComboInfo();
            //c1_13_5.ID = "1305";
            //c1_13_5.Name = "キャスケット";
            //c1_13_0.Children.Add(c1_13_5);

            ConnectedComboInfo c1_14_1 = new ConnectedComboInfo();
            c1_14_1.ID = "1401";
            c1_14_1.Name = "小物 / アクセサリー";
            c1_14_0.Children.Add(c1_14_1);
            ConnectedComboInfo c1_14_2 = new ConnectedComboInfo();
            c1_14_2.ID = "1402";
            c1_14_2.Name = "素材 / パーツ";
            c1_14_0.Children.Add(c1_14_2);

            ConnectedComboInfo c1_15_1 = new ConnectedComboInfo();
            c1_15_1.ID = "1501";
            c1_15_1.Name = "ベルト";
            c1_15_0.Children.Add(c1_15_1);
            ConnectedComboInfo c1_15_2 = new ConnectedComboInfo();
            c1_15_2.ID = "1502";
            c1_15_2.Name = "サングラス / メガネ";
            c1_15_0.Children.Add(c1_15_2);
            ConnectedComboInfo c1_15_3 = new ConnectedComboInfo();
            c1_15_3.ID = "1503";
            c1_15_3.Name = "腕時計";
            c1_15_0.Children.Add(c1_15_3);
            ConnectedComboInfo c1_15_4 = new ConnectedComboInfo();
            c1_15_4.ID = "1504";
            c1_15_4.Name = "財布";
            c1_15_0.Children.Add(c1_15_4);
            //ConnectedComboInfo c1_15_5 = new ConnectedComboInfo();
            //c1_15_5.ID = "1505";
            //c1_15_5.Name = "マフラー / ショール";
            //c1_15_0.Children.Add(c1_15_5);
            //ConnectedComboInfo c1_15_6 = new ConnectedComboInfo();
            //c1_15_6.ID = "1506";
            //c1_15_6.Name = "ストール / パシュミナ";
            //c1_15_0.Children.Add(c1_15_6);
            ConnectedComboInfo c1_15_7 = new ConnectedComboInfo();
            c1_15_7.ID = "1507";
            c1_15_7.Name = "モバイルケース、カバー";
            c1_15_0.Children.Add(c1_15_7);
            //ConnectedComboInfo c1_15_8 = new ConnectedComboInfo();
            //c1_15_8.ID = "1508";
            //c1_15_8.Name = "ポーチ";
            //c1_15_0.Children.Add(c1_15_8);
            //ConnectedComboInfo c1_15_9 = new ConnectedComboInfo();
            //c1_15_9.ID = "1509";
            //c1_15_9.Name = "ストラップ / イヤホンジャック";
            //c1_15_0.Children.Add(c1_15_9);
            //ConnectedComboInfo c1_15_10 = new ConnectedComboInfo();
            //c1_15_10.ID = "1510";
            //c1_15_10.Name = "イヤーマフ";
            //c1_15_0.Children.Add(c1_15_10);
            //ConnectedComboInfo c1_15_11 = new ConnectedComboInfo();
            //c1_15_11.ID = "1511";
            //c1_15_11.Name = "手袋";
            //c1_15_0.Children.Add(c1_15_11);
            //ConnectedComboInfo c1_15_12 = new ConnectedComboInfo();
            //c1_15_12.ID = "1512";
            //c1_15_12.Name = "バンダナ / スカーフ";
            //c1_15_0.Children.Add(c1_15_12);
            //ConnectedComboInfo c1_15_13 = new ConnectedComboInfo();
            //c1_15_13.ID = "1513";
            //c1_15_13.Name = "ハンカチ";
            //c1_15_0.Children.Add(c1_15_13);
            //ConnectedComboInfo c1_15_14 = new ConnectedComboInfo();
            //c1_15_14.ID = "1514";
            //c1_15_14.Name = "名刺入れ / 定期入れ";
            //c1_15_0.Children.Add(c1_15_14);
            //ConnectedComboInfo c1_15_15 = new ConnectedComboInfo();
            //c1_15_15.ID = "1515";
            //c1_15_15.Name = "キーホルダー";
            //c1_15_0.Children.Add(c1_15_15);
            //ConnectedComboInfo c1_15_16 = new ConnectedComboInfo();
            //c1_15_16.ID = "1516";
            //c1_15_16.Name = "ネクタイ";
            //c1_15_0.Children.Add(c1_15_16);
            //ConnectedComboInfo c1_15_17 = new ConnectedComboInfo();
            //c1_15_17.ID = "1517";
            //c1_15_17.Name = "サスペンダー";
            //c1_15_0.Children.Add(c1_15_17);
            //ConnectedComboInfo c1_15_18 = new ConnectedComboInfo();
            //c1_15_18.ID = "1518";
            //c1_15_18.Name = "ネックウォーマー";
            //c1_15_0.Children.Add(c1_15_18);
            //ConnectedComboInfo c1_15_19 = new ConnectedComboInfo();
            //c1_15_19.ID = "1519";
            //c1_15_19.Name = "コインケース";
            //c1_15_0.Children.Add(c1_15_19);
            //ConnectedComboInfo c1_15_20 = new ConnectedComboInfo();
            //c1_15_20.ID = "1520";
            //c1_15_20.Name = "傘";
            //c1_15_0.Children.Add(c1_15_20);
            //ConnectedComboInfo c1_15_21 = new ConnectedComboInfo();
            //c1_15_21.ID = "1521";
            //c1_15_21.Name = "小物その他";
            //c1_15_0.Children.Add(c1_15_21);

            ConnectedComboInfo c1_16_1 = new ConnectedComboInfo();
            c1_16_1.ID = "1601";
            c1_16_1.Name = "ショート / ボブ";
            c1_16_0.Children.Add(c1_16_1);
            ConnectedComboInfo c1_16_2= new ConnectedComboInfo();
            c1_16_2.ID = "1603";
            c1_16_2.Name = "ミディアム";
            c1_16_0.Children.Add(c1_16_2);
            ConnectedComboInfo c1_16_3 = new ConnectedComboInfo();
            c1_16_3.ID = "1604";
            c1_16_3.Name = "ロング";
            c1_16_0.Children.Add(c1_16_3);
            ConnectedComboInfo c1_16_4 = new ConnectedComboInfo();
            c1_16_4.ID = "1605";
            c1_16_4.Name = "前髪 / パーツウィッグ";
            c1_16_0.Children.Add(c1_16_4);
            ConnectedComboInfo c1_16_5 = new ConnectedComboInfo();
            c1_16_5.ID = "1606";
            c1_16_5.Name = "エクステ";
            c1_16_0.Children.Add(c1_16_5);
            ConnectedComboInfo c1_16_6 = new ConnectedComboInfo();
            c1_16_6.ID = "1607";
            c1_16_6.Name = "ウィッグ小物";
            c1_16_0.Children.Add(c1_16_6);

            ConnectedComboInfo c1_17_1 = new ConnectedComboInfo();
            c1_17_1.ID = "1701";
            c1_17_1.Name = "メイクアップ";
            c1_17_0.Children.Add(c1_17_1);
            ConnectedComboInfo c1_17_2 = new ConnectedComboInfo();
            c1_17_2.ID = "1702";
            c1_17_2.Name = "ネイルチップ";
            c1_17_0.Children.Add(c1_17_2);
            ConnectedComboInfo c1_17_3 = new ConnectedComboInfo();
            c1_17_3.ID = "1703";
            c1_17_3.Name = "ネイルケア";
            c1_17_0.Children.Add(c1_17_3);
            ConnectedComboInfo c1_17_4 = new ConnectedComboInfo();
            c1_17_4.ID = "1704";
            c1_17_4.Name = "ネイル / デコパーツ";
            c1_17_0.Children.Add(c1_17_4);
            ConnectedComboInfo c1_17_5 = new ConnectedComboInfo();
            c1_17_5.ID = "1705";
            c1_17_5.Name = "香水";
            c1_17_0.Children.Add(c1_17_5);
            ConnectedComboInfo c1_17_6 = new ConnectedComboInfo();
            c1_17_6.ID = "1706";
            c1_17_6.Name = "ヘアケア";
            c1_17_0.Children.Add(c1_17_6);
            ConnectedComboInfo c1_17_7 = new ConnectedComboInfo();
            c1_17_7.ID = "1707";
            c1_17_7.Name = "ボディケア";
            c1_17_0.Children.Add(c1_17_7);
            ConnectedComboInfo c1_17_8 = new ConnectedComboInfo();
            c1_17_8.ID = "1708";
            c1_17_8.Name = "ハンドケア";
            c1_17_0.Children.Add(c1_17_8);
            ConnectedComboInfo c1_17_9 = new ConnectedComboInfo();
            c1_17_9.ID = "1709";
            c1_17_9.Name = "カラコン";
            c1_17_0.Children.Add(c1_17_9);
            ConnectedComboInfo c1_17_10 = new ConnectedComboInfo();
            c1_17_10.ID = "1710";
            c1_17_10.Name = "サプリメント";
            c1_17_0.Children.Add(c1_17_10);

            ConnectedComboInfo c1_18_1 = new ConnectedComboInfo();
            c1_18_1.ID = "1801";
            c1_18_1.Name = "浴衣";
            c1_18_0.Children.Add(c1_18_1);
            ConnectedComboInfo c1_18_2 = new ConnectedComboInfo();
            c1_18_2.ID = "1802";
            c1_18_2.Name = "浴衣帯";
            c1_18_0.Children.Add(c1_18_2);
            ConnectedComboInfo c1_18_3 = new ConnectedComboInfo();
            c1_18_3.ID = "1803";
            c1_18_3.Name = "着物";
            c1_18_0.Children.Add(c1_18_3);
            ConnectedComboInfo c1_18_4 = new ConnectedComboInfo();
            c1_18_4.ID = "1804";
            c1_18_4.Name = "振袖";
            c1_18_0.Children.Add(c1_18_4);
            ConnectedComboInfo c1_18_5 = new ConnectedComboInfo();
            c1_18_5.ID = "1805";
            c1_18_5.Name = "帯";
            c1_18_0.Children.Add(c1_18_5);
            ConnectedComboInfo c1_18_6 = new ConnectedComboInfo();
            c1_18_6.ID = "1806";
            c1_18_6.Name = "和装小物";
            c1_18_0.Children.Add(c1_18_6);
            ConnectedComboInfo c1_18_7 = new ConnectedComboInfo();
            c1_18_7.ID = "1807";
            c1_18_7.Name = "水着";
            c1_18_0.Children.Add(c1_18_7);
            ConnectedComboInfo c1_18_8 = new ConnectedComboInfo();
            c1_18_8.ID = "1808";
            c1_18_8.Name = "和装その他";
            c1_18_0.Children.Add(c1_18_8);

            ConnectedComboInfo c1_19_1 = new ConnectedComboInfo();
            c1_19_1.ID = "1901";
            c1_19_1.Name = "スーツ";
            c1_19_0.Children.Add(c1_19_1);
            ConnectedComboInfo c1_19_2 = new ConnectedComboInfo();
            c1_19_2.ID = "1902";
            c1_19_2.Name = "ドレス";
            c1_19_0.Children.Add(c1_19_2);


            ConnectedComboInfo c2_0_0 = new ConnectedComboInfo();
            c2_0_0.ID = "";
            c2_0_0.Name = "マタニティ/ベビー/キッズ";
            //list.Add(c2_0_0);
            ConnectedComboInfo c2_1_0 = new ConnectedComboInfo();
            c2_1_0.ID = "2001";
            c2_1_0.Name = "マタニティウェア";
            c2_0_0.Children.Add(c2_1_0);
            ConnectedComboInfo c2_2_0 = new ConnectedComboInfo();
            c2_2_0.ID = "2002";
            c2_2_0.Name = "マタニティグッズ";
            c2_0_0.Children.Add(c2_2_0);
            ConnectedComboInfo c2_3_0 = new ConnectedComboInfo();
            c2_3_0.ID = "2003";
            c2_3_0.Name = "ベビーウェア";
            c2_0_0.Children.Add(c2_3_0);
            ConnectedComboInfo c2_4_0 = new ConnectedComboInfo();
            c2_4_0.ID = "2005";
            c2_4_0.Name = "ベビーシューズ";
            c2_0_0.Children.Add(c2_4_0);
            ConnectedComboInfo c2_5_0 = new ConnectedComboInfo();
            c2_5_0.ID = "2006";
            c2_5_0.Name = "ベビー用品";
            c2_0_0.Children.Add(c2_5_0);
            ConnectedComboInfo c2_6_0 = new ConnectedComboInfo();
            c2_6_0.ID = "2007";
            c2_6_0.Name = "ベビーカー";
            c2_0_0.Children.Add(c2_6_0);
            ConnectedComboInfo c2_7_0 = new ConnectedComboInfo();
            c2_7_0.ID = "2008";
            c2_7_0.Name = "キッズウェア(男の子用)";
            c2_0_0.Children.Add(c2_7_0);
            ConnectedComboInfo c2_8_0 = new ConnectedComboInfo();
            c2_8_0.ID = "2009";
            c2_8_0.Name = "キッズウェア(女の子用)";
            c2_0_0.Children.Add(c2_8_0);
            ConnectedComboInfo c2_9_0 = new ConnectedComboInfo();
            c2_9_0.ID = "2010";
            c2_9_0.Name = "キッズシューズ";
            c2_0_0.Children.Add(c2_9_0);
            ConnectedComboInfo c2_10_0 = new ConnectedComboInfo();
            c2_10_0.ID = "2011";
            c2_10_0.Name = "キッズバッグ";
            c2_0_0.Children.Add(c2_10_0);
            ConnectedComboInfo c2_11_0 = new ConnectedComboInfo();
            c2_11_0.ID = "2012";
            c2_11_0.Name = "キッズ小物";
            c2_0_0.Children.Add(c2_11_0);
            ConnectedComboInfo c2_12_0 = new ConnectedComboInfo();
            c2_12_0.ID = "2013";
            c2_12_0.Name = "おもちゃ";
            c2_0_0.Children.Add(c2_12_0);

            ConnectedComboInfo c3_0_0 = new ConnectedComboInfo();
            c3_0_0.ID = "";
            c3_0_0.Name = "本・CD・DVD・ゲーム";
            //list.Add(c3_0_0);
            ConnectedComboInfo c3_1_0 = new ConnectedComboInfo();
            c3_1_0.ID = "9101";
            c3_1_0.Name = "本・雑誌";
            c3_0_0.Children.Add(c3_1_0);
            ConnectedComboInfo c3_2_0 = new ConnectedComboInfo();
            c3_2_0.ID = "9102";
            c3_2_0.Name = "漫画";
            c3_0_0.Children.Add(c3_2_0);
            ConnectedComboInfo c3_3_0 = new ConnectedComboInfo();
            c3_3_0.ID = "9103";
            c3_3_0.Name = "CD";
            c3_0_0.Children.Add(c3_3_0);
            ConnectedComboInfo c3_4_0 = new ConnectedComboInfo();
            c3_4_0.ID = "9104";
            c3_4_0.Name = "DVD";
            c3_0_0.Children.Add(c3_4_0);
            ConnectedComboInfo c3_5_0 = new ConnectedComboInfo();
            c3_5_0.ID = "9105";
            c3_5_0.Name = "ゲーム";
            c3_0_0.Children.Add(c3_5_0);

            ConnectedComboInfo c4_0_0 = new ConnectedComboInfo();
            c4_0_0.ID = "";
            c4_0_0.Name = "ぬいぐるみ・キャラクターグッズ・おもちゃ";
            //list.Add(c4_0_0);
            ConnectedComboInfo c4_1_0 = new ConnectedComboInfo();
            c4_1_0.ID = "9201";
            c4_1_0.Name = "おもちゃ";
            c4_0_0.Children.Add(c4_1_0);
            ConnectedComboInfo c4_2_0 = new ConnectedComboInfo();
            c4_2_0.ID = "9202";
            c4_2_0.Name = "ぬいぐるみ";
            c4_0_0.Children.Add(c4_2_0);
            ConnectedComboInfo c4_3_0 = new ConnectedComboInfo();
            c4_3_0.ID = "9203";
            c4_3_0.Name = "キャラクターグッズ";
            c4_0_0.Children.Add(c4_3_0);

            ConnectedComboInfo c5_0_0 = new ConnectedComboInfo();
            c5_0_0.ID = "";
            c5_0_0.Name = "コミック、アニメ、タレントグッズ";
            //list.Add(c5_0_0);
            ConnectedComboInfo c5_1_0 = new ConnectedComboInfo();
            c5_1_0.ID = "9301";
            c5_1_0.Name = "アイドル関連";
            c5_0_0.Children.Add(c5_1_0);
            ConnectedComboInfo c5_2_0 = new ConnectedComboInfo();
            c5_2_0.ID = "9302";
            c5_2_0.Name = "トレーディングカード";
            c5_0_0.Children.Add(c5_2_0);
            ConnectedComboInfo c5_3_0 = new ConnectedComboInfo();
            c5_3_0.ID = "9303";
            c5_3_0.Name = "コミック・アニメ本・音楽・ＤＶＤ";
            c5_0_0.Children.Add(c5_3_0);
            ConnectedComboInfo c5_4_0 = new ConnectedComboInfo();
            c5_4_0.ID = "9304";
            c5_4_0.Name = "コミック・アニメグッズ";
            c5_0_0.Children.Add(c5_4_0);
            ConnectedComboInfo c5_5_0 = new ConnectedComboInfo();
            c5_5_0.ID = "9305";
            c5_5_0.Name = "男性ミュージシャン関連";
            c5_0_0.Children.Add(c5_5_0);
            ConnectedComboInfo c5_6_0 = new ConnectedComboInfo();
            c5_6_0.ID = "9306";
            c5_6_0.Name = "女性ミュージシャン関連";
            c5_0_0.Children.Add(c5_6_0);
            ConnectedComboInfo c5_7_0 = new ConnectedComboInfo();
            c5_7_0.ID = "9307";
            c5_7_0.Name = "グループミュージシャン関連";
            c5_0_0.Children.Add(c5_7_0);
            ConnectedComboInfo c5_8_0 = new ConnectedComboInfo();
            c5_8_0.ID = "9308";
            c5_8_0.Name = "お笑い芸人関連";
            c5_0_0.Children.Add(c5_8_0);
            ConnectedComboInfo c5_9_0 = new ConnectedComboInfo();
            c5_9_0.ID = "9309";
            c5_9_0.Name = "海外アーティスト関連";
            c5_0_0.Children.Add(c5_9_0);
            ConnectedComboInfo c5_10_0 = new ConnectedComboInfo();
            c5_10_0.ID = "9310";
            c5_10_0.Name = "その他タレント関連商品";
            c5_0_0.Children.Add(c5_10_0);

            ConnectedComboInfo c6_0_0 = new ConnectedComboInfo();
            c6_0_0.ID = "";
            c6_0_0.Name = "インテリア・住まい・雑貨";
            //list.Add(c6_0_0);
            ConnectedComboInfo c6_1_0 = new ConnectedComboInfo();
            c6_1_0.ID = "9401";
            c6_1_0.Name = "キッチン / 食器";
            c6_0_0.Children.Add(c6_1_0);
            ConnectedComboInfo c6_2_0 = new ConnectedComboInfo();
            c6_2_0.ID = "9402";
            c6_2_0.Name = "家具";
            c6_0_0.Children.Add(c6_2_0);
            ConnectedComboInfo c6_3_0 = new ConnectedComboInfo();
            c6_3_0.ID = "9403";
            c6_3_0.Name = "ライト / 照明";
            c6_0_0.Children.Add(c6_3_0);
            ConnectedComboInfo c6_4_0 = new ConnectedComboInfo();
            c6_4_0.ID = "9404";
            c6_4_0.Name = "寝具";
            c6_0_0.Children.Add(c6_4_0);
            ConnectedComboInfo c6_5_0 = new ConnectedComboInfo();
            c6_5_0.ID = "9405";
            c6_5_0.Name = "雑貨";
            c6_0_0.Children.Add(c6_5_0);
            ConnectedComboInfo c6_6_0 = new ConnectedComboInfo();
            c6_6_0.ID = "9406";
            c6_6_0.Name = "その他";
            c6_0_0.Children.Add(c6_6_0);

            ConnectedComboInfo c7_0_0 = new ConnectedComboInfo();
            c7_0_0.ID = "";
            c7_0_0.Name = "家電・スマホ";
            //list.Add(c7_0_0);
            ConnectedComboInfo c7_1_0 = new ConnectedComboInfo();
            c7_1_0.ID = "9501";
            c7_1_0.Name = "携帯電話 / スマートフォン";
            c7_0_0.Children.Add(c7_1_0);
            ConnectedComboInfo c7_2_0 = new ConnectedComboInfo();
            c7_2_0.ID = "9502";
            c7_2_0.Name = "生活家電";
            c7_0_0.Children.Add(c7_2_0);
            ConnectedComboInfo c7_3_0 = new ConnectedComboInfo();
            c7_3_0.ID = "9503";
            c7_3_0.Name = "カメラ";
            c7_0_0.Children.Add(c7_3_0);
            ConnectedComboInfo c7_4_0 = new ConnectedComboInfo();
            c7_4_0.ID = "9504";
            c7_4_0.Name = "PC";
            c7_0_0.Children.Add(c7_4_0);
            ConnectedComboInfo c7_5_0 = new ConnectedComboInfo();
            c7_5_0.ID = "9505";
            c7_5_0.Name = "テレビ / 映像機器";
            c7_0_0.Children.Add(c7_5_0);
            ConnectedComboInfo c7_6_0 = new ConnectedComboInfo();
            c7_6_0.ID = "9506";
            c7_6_0.Name = "オーディオ機器";
            c7_0_0.Children.Add(c7_6_0);
            ConnectedComboInfo c7_7_0 = new ConnectedComboInfo();
            c7_7_0.ID = "9507";
            c7_7_0.Name = "その他";
            c7_0_0.Children.Add(c7_7_0);


            ConnectedComboInfo c8_0_0 = new ConnectedComboInfo();
            c8_0_0.ID = "";
            c8_0_0.Name = "文房具";
            //list.Add(c8_0_0);
            ConnectedComboInfo c8_1_0 = new ConnectedComboInfo();
            c8_1_0.ID = "9601";
            c8_1_0.Name = "筆記用具";
            c8_0_0.Children.Add(c8_1_0);
            ConnectedComboInfo c8_2_0 = new ConnectedComboInfo();
            c8_2_0.ID = "9602";
            c8_2_0.Name = "ノート・バインダー";
            c8_0_0.Children.Add(c8_2_0);
            ConnectedComboInfo c8_3_0 = new ConnectedComboInfo();
            c8_3_0.ID = "9603";
            c8_3_0.Name = "包装用品";
            c8_0_0.Children.Add(c8_3_0);
            ConnectedComboInfo c8_4_0 = new ConnectedComboInfo();
            c8_4_0.ID = "9604";
            c8_4_0.Name = "その他文房具";
            c8_0_0.Children.Add(c8_4_0);


            ConnectedComboInfo c9_0_0 = new ConnectedComboInfo();
            c9_0_0.ID = "";
            c9_0_0.Name = "その他";
            //list.Add(c9_0_0);
            ConnectedComboInfo c9_1_0 = new ConnectedComboInfo();
            c9_1_0.ID = "9901";
            c9_1_0.Name = "カルチャー";
            c9_0_0.Children.Add(c9_1_0);
            ConnectedComboInfo c9_2_0 = new ConnectedComboInfo();
            c9_2_0.ID = "9902";
            c9_2_0.Name = "レジャー・スポーツ";
            c9_0_0.Children.Add(c9_2_0);
            ConnectedComboInfo c9_3_0 = new ConnectedComboInfo();
            c9_3_0.ID = "9903";
            c9_3_0.Name = "自動車用品";
            c9_0_0.Children.Add(c9_3_0);
            ConnectedComboInfo c9_4_0 = new ConnectedComboInfo();
            c9_4_0.ID = "9904";
            c9_4_0.Name = "ペット用品";
            c9_0_0.Children.Add(c9_4_0);
            ConnectedComboInfo c9_5_0 = new ConnectedComboInfo();
            c9_5_0.ID = "9905";
            c9_5_0.Name = "食品";
            c9_0_0.Children.Add(c9_5_0);
            ConnectedComboInfo c9_6_0 = new ConnectedComboInfo();
            c9_6_0.ID = "9906";
            c9_6_0.Name = "楽器・機材";
            c9_0_0.Children.Add(c9_6_0);
            ConnectedComboInfo c9_7_0 = new ConnectedComboInfo();
            c9_7_0.ID = "9999";
            c9_7_0.Name = "その他";
            c9_0_0.Children.Add(c9_7_0);

            return list;
        }

        public static List<Info> GetDatatSourceForStatus()
        {
            List<Info> list = new List<Info>();
            list.Add(new Info()
            {
                ID = "1Status",
                Name = "新品、未使用"
            });
            list.Add(new Info()
            {
                ID = "2Status",
                Name = "未使用に近い"
            });
            list.Add(new Info()
            {
                ID = "3Status",
                Name = "目立った傷や汚れなし"
            });
            list.Add(new Info()
            {
                ID = "4Status",
                Name = "やや傷や汚れあり"
            });
            list.Add(new Info()
            {
                ID = "5Status",
                Name = "傷や汚れあり"
            });
            list.Add(new Info()
            {
                ID = "6Status",
                Name = "全面的に状態が悪い"
            });
            return list;
        }

        public static List<LogisticLiaoInfo> GetDatatSourceForLoggisticLiao()
        {
            List<LogisticLiaoInfo> list = new List<LogisticLiaoInfo>();
            LogisticLiaoInfo liao1 = new LogisticLiaoInfo()
            {
                ID = "carry1",
                Name = "商品価格に込み"
            };
            List<Info> logisticWayFor1 = new List<Info>();
            logisticWayFor1.Add(new Info()
            {
                ID = "sendMethod0",
                Name = "未定"
            });
            logisticWayFor1.Add(new Info()
            {
                ID = "sendMethod1",
                Name = "普通郵便(定形/定形外)"
            });
            logisticWayFor1.Add(new Info()
            {
                ID = "sendMethod2",
                Name = "ゆうパック"
            });
            logisticWayFor1.Add(new Info()
            {
                ID = "sendMethod3",
                Name = "レターパックプラス"
            });
            logisticWayFor1.Add(new Info()
            {
                ID = "sendMethod4",
                Name = "レターパックライト"
            });
            logisticWayFor1.Add(new Info()
            {
                ID = "sendMethod6",
                Name = "ヤマト宅急便"
            });
            logisticWayFor1.Add(new Info()
            {
                ID = "sendMethod8",
                Name = "はこBOON"
            });
            logisticWayFor1.Add(new Info()
            {
                ID = "sendMethod81",
                Name = "クリックポスト"
            });
            logisticWayFor1.Add(new Info()
            {
                ID = "sendMethod82",
                Name = "飛脚メール便"
            });
            logisticWayFor1.Add(new Info()
            {
                ID = "sendMethod83",
                Name = "飛脚宅急便"
            });
            logisticWayFor1.Add(new Info()
            {
                ID = "sendMethod84",
                Name = "カンガルーミニ便"
            });
            logisticWayFor1.Add(new Info()
            {
                ID = "sendMethod85",
                Name = "宅急便コンパクト"
            });
            logisticWayFor1.Add(new Info()
            {
                ID = "sendMethod86",
                Name = "ゆうメール"
            });
            logisticWayFor1.Add(new Info()
            {
                ID = "sendMethod87",
                Name = "スマートレター"
            });
            logisticWayFor1.Add(new Info()
            {
                ID = "sendMethod88",
                Name = "ゆうパケット"
            });
            liao1.ChildrenLogisticWay = logisticWayFor1;
            list.Add(liao1);

            LogisticLiaoInfo liao2 = new LogisticLiaoInfo()
            {
                ID = "carry0",
                Name = "商品価格とは別途"
            };
            List<Info> logisticWayFor2 = new List<Info>();
            logisticWayFor2.Add(new Info()
            {
                ID = "sendMethod0",
                Name = "未定"
            });
            logisticWayFor2.Add(new Info()
            {
                ID = "sendMethod11",
                Name = "ゆうパック着払い"
            });
            logisticWayFor2.Add(new Info()
            {
                ID = "sendMethod12",
                Name = "ヤマト宅急便"
            });
            logisticWayFor2.Add(new Info()
            {
                ID = "sendMethod17",
                Name = "飛脚宅急便"
            });
            logisticWayFor2.Add(new Info()
            {
                ID = "sendMethod19",
                Name = "ゆうメール着払い"
            });
            logisticWayFor2.Add(new Info()
            {
                ID = "sendMethod20",
                Name = "ゆうパケット着払い"
            });
            liao2.ChildrenLogisticWay = logisticWayFor2;
            list.Add(liao2);
            return list;
        }

        public static List<Info> GetDatatSourceForArea()
        {
            string content =
                "北海道,青森県,岩手県,宮城県,秋田県,山形県,福島県,福井県,新潟県,富山県,石川県,山梨県,長野県,岐阜県,静岡県,愛知県,東京都,神奈川県,千葉県,埼玉県,群馬県,栃木県,茨城県,三重県,兵庫県,奈良県,大阪府,滋賀県,京都府,和歌山県,島根県,岡山県,広島県,山口県,鳥取県,徳島県,香川県,愛媛県,高知県,福岡県,佐賀県,長崎県,熊本県,大分県,宮崎県,鹿児島県,沖縄県";
            List<Info> list = new List<Info>(); 
            list.Add(new Info()
            {
                ID = "0",
                Name = "選択してください"
            });
            string[] areas = content.Split(',');
            for (int i = 0; i < areas.Length; i++)
            {
                string area = areas[i];
                Info info = new Info()
                {
                    ID = "area" + (i+1).ToString() + "SendData",
                    Name = area
                };
                list.Add(info);
            }
            return list;
        }

        public static List<Info> GetDatatSourceForDelierDate()
        {
            List<Info> list = new List<Info>();
            list.Add(new Info()
            {
                ID = "0SendData",
                Name = "指定なし"
            });
            list.Add(new Info()
            {
                ID = "1SendData",
                Name = "1～2日で発送"
            });
            list.Add(new Info()
            {
                ID = "2SendData",
                Name = "2～3日で発送"
            });
            list.Add(new Info()
            {
                ID = "3SendData",
                Name = "4～7日で発送"
            });
            list.Add(new Info()
            {
                ID = "4SendData",
                Name = "発送は週末のみ"
            });
            list.Add(new Info()
            {
                ID = "5SendData",
                Name = "発送は平日のみ"
            });
            return list;
        }

    }

    public class Info
    {
        public string ID { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }

    public class ConnectedComboInfo
    {
        public string ID { get; set; }
        public string Name { get; set; }

        public string LevelOneID { get; set; }
        public string LevelTwoID { get; set; }
        public string LevelThreeID { get; set; }

        public string LevelOneName { get; set; }
        public string LevelTwoName { get; set; }
        public string LevelThreeName { get; set; }

        public List<ConnectedComboInfo> Children { get; set; }

        public ConnectedComboInfo()
        {
            this.Children = new List<ConnectedComboInfo>();
        }

        public override string ToString()
        {
            return LevelOneName + ">" + LevelTwoName + ">" + LevelThreeName;
        }
    }

    public class LogisticLiaoInfo : Info
    {
        public List<Info> ChildrenLogisticWay { get; set; }

        public LogisticLiaoInfo()
        {
            this.ChildrenLogisticWay = new List<Info>();
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
