using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RuneList : MonoBehaviour
{

    public enum Patern
    {
        NotInitialized,
        O,
        C,
        Z,
        B,
        Bow,
        Flag,
        Staf,
        Corne,
        Label,
        Balai,
        Ivrogne,
        Empoule,
        Epice,
        Max,
    }


	Vector2[][]runes;

    private void Awake()
    {
        runes = new Vector2[(int)Patern.Max][];

        runes[(int)Patern.NotInitialized] = new Vector2[0];

        runes[(int)Patern.C] = new Vector2[] { new Vector2(-0.3490258f, 2.7886f), new Vector2(0.08387457f, 2.680376f), new Vector2(0.2281747f, 2.608225f), new Vector2(0.5348125f, 2.42785f), new Vector2(0.7873378f, 2.049062f), new Vector2(0.8955628f, 1.652237f), new Vector2(0.9496754f, 1.345599f), new Vector2(0.9677128f, 1.002886f), new Vector2(0.9496754f, 0.4256856f), new Vector2(0.9136002f, 0.2092355f), new Vector2(0.7512629f, -0.2056274f), new Vector2(0.6069625f, -0.4040402f), new Vector2(0.3003248f, -0.7647905f), new Vector2(0.101912f, -0.9090903f), new Vector2(-0.2227633f, -1.143578f), new Vector2(-0.6195887f, -1.305916f), new Vector2(-0.9081889f, -1.305916f) };

        runes[(int)Patern.Z] = new Vector2[] { new Vector2(-1.645833f, 2.614583f), new Vector2(-1.46875f, 2.614583f), new Vector2(-1.28125f, 2.625f), new Vector2(-1.114583f, 2.625f), new Vector2(-0.9374999f, 2.635417f), new Vector2(-0.7604166f, 2.635417f), new Vector2(-0.5937501f, 2.635417f), new Vector2(-0.4375f, 2.635417f), new Vector2(-0.25f, 2.635417f), new Vector2(-0.07291669f, 2.635417f), new Vector2(0.09374991f, 2.635417f), new Vector2(0.2604167f, 2.645833f), new Vector2(0.4375001f, 2.65625f), new Vector2(0.6041666f, 2.666667f), new Vector2(0.7708334f, 2.6875f), new Vector2(0.9583335f, 2.697917f), new Vector2(1.125f, 2.708333f), new Vector2(1.291667f, 2.71875f), new Vector2(1.46875f, 2.729167f), new Vector2(1.635417f, 2.729167f), new Vector2(1.8125f, 2.71875f), new Vector2(1.927083f, 2.59375f), new Vector2(1.947917f, 2.416667f), new Vector2(1.895833f, 2.260417f), new Vector2(1.770833f, 2.135417f), new Vector2(1.635417f, 2.020833f), new Vector2(1.5f, 1.90625f), new Vector2(1.354167f, 1.822917f), new Vector2(1.229167f, 1.708333f), new Vector2(1.083333f, 1.59375f), new Vector2(0.9479168f, 1.510417f), new Vector2(0.8020834f, 1.395833f), new Vector2(0.6562501f, 1.291667f), new Vector2(0.5312501f, 1.197917f), new Vector2(0.3958334f, 1.083333f), new Vector2(0.2604167f, 0.9791666f), new Vector2(0.1041666f, 0.875f), new Vector2(-0.02083339f, 0.78125f), new Vector2(-0.1562501f, 0.6458333f), new Vector2(-0.25f, 0.53125f), new Vector2(-0.375f, 0.3854167f), new Vector2(-0.4895833f, 0.28125f), new Vector2(-0.6458334f, 0.15625f), new Vector2(-0.7708334f, 0.05208349f), new Vector2(-0.8854166f, -0.05208302f), new Vector2(-1.020833f, -0.1666665f), new Vector2(-1.145833f, -0.3020835f), new Vector2(-1.270833f, -0.416667f), new Vector2(-1.375f, -0.53125f), new Vector2(-1.5f, -0.677083f), new Vector2(-1.59375f, -0.8020833f), new Vector2(-1.739583f, -0.90625f), new Vector2(-1.864583f, -1.020833f), new Vector2(-1.895833f, -1.1875f), new Vector2(-1.791667f, -1.333333f), new Vector2(-1.645833f, -1.416667f), new Vector2(-1.479167f, -1.458333f), new Vector2(-1.302083f, -1.458333f), new Vector2(-1.135417f, -1.46875f), new Vector2(-0.9270833f, -1.46875f), new Vector2(-0.7708334f, -1.46875f), new Vector2(-0.6145833f, -1.46875f), new Vector2(-0.4166666f, -1.46875f), new Vector2(-0.2187501f, -1.46875f), new Vector2(-0.0625f, -1.46875f), new Vector2(0.1041666f, -1.46875f), new Vector2(0.2916667f, -1.46875f), new Vector2(0.4895833f, -1.46875f), new Vector2(0.5937499f, -1.46875f), new Vector2(0.7812501f, -1.46875f), new Vector2(0.9583335f, -1.447917f), new Vector2(1.125f, -1.427083f), new Vector2(1.270833f, -1.40625f), new Vector2(1.447917f, -1.375f), new Vector2(1.614583f, -1.333333f), new Vector2(1.770833f, -1.3125f), new Vector2(1.958333f, -1.3125f) };

        runes[(int)Patern.B] = new Vector2[] { new Vector2(-0.9934571f, -2.940771f), new Vector2(-1.010675f, -2.561983f), new Vector2(-1.010675f, -2.183195f), new Vector2(-0.9934571f, -1.821625f), new Vector2(-0.9762397f, -1.425619f), new Vector2(-0.959022f, -1.06405f), new Vector2(-0.9418043f, -0.6852615f), new Vector2(-0.9073691f, -0.2892557f), new Vector2(-0.8901514f, 0.08953214f), new Vector2(-0.8729339f, 0.4683203f), new Vector2(-0.8557162f, 0.8815426f), new Vector2(-0.8557162f, 1.260331f), new Vector2(-0.8557162f, 1.690772f), new Vector2(-0.8557162f, 2.017906f), new Vector2(-0.8384985f, 2.396694f), new Vector2(-0.821281f, 2.775482f), new Vector2(-0.821281f, 3.15427f), new Vector2(-0.5113637f, 2.896006f), new Vector2(-0.2530992f, 2.586088f), new Vector2(-0.01205233f, 2.327824f), new Vector2(0.2806474f, 2.052342f), new Vector2(0.5389119f, 1.77686f), new Vector2(0.7455235f, 1.432507f), new Vector2(0.5216942f, 1.139808f), new Vector2(0.1429065f, 0.915978f), new Vector2(-0.1497935f, 0.7093668f), new Vector2(-0.4769283f, 0.502755f), new Vector2(-0.8040633f, 0.3477961f), new Vector2(-0.5974517f, 0.02066135f), new Vector2(-0.3047521f, -0.2720383f), new Vector2(-0.08092292f, -0.5819553f), new Vector2(0.1429065f, -0.8746555f), new Vector2(0.3839533f, -1.167355f), new Vector2(0.6766528f, -1.442837f), new Vector2(0.3150826f, -1.632231f), new Vector2(0.03960051f, -1.890495f), new Vector2(-0.218664f, -2.165978f), new Vector2(-0.4941459f, -2.44146f), new Vector2(-0.7696282f, -2.716942f) };

        runes[(int)Patern.Bow] = new Vector2[] { new Vector2(1.038223f, 2.86157f), new Vector2(0.8316116f, 2.603306f), new Vector2(0.5733471f, 2.293389f), new Vector2(0.3667355f, 2.017906f), new Vector2(0.09125362f, 1.725207f), new Vector2(-0.1842286f, 1.449724f), new Vector2(-0.356405f, 1.897383f), new Vector2(-0.4769283f, 2.103994f), new Vector2(-0.7179752f, 2.448348f), new Vector2(-0.9762397f, 2.741047f), new Vector2(-1.200069f, 3.01653f), new Vector2(-1.286157f, 2.620523f), new Vector2(-1.268939f, 2.13843f), new Vector2(-1.251722f, 1.862948f), new Vector2(-1.217286f, 1.380854f), new Vector2(-1.182851f, 1.070937f), new Vector2(-1.165634f, 0.7610196f), new Vector2(-1.131198f, 0.1584023f), new Vector2(-1.131198f, 0.02066135f), new Vector2(-1.113981f, -0.2548209f), new Vector2(-1.113981f, -0.6336087f), new Vector2(-1.131198f, -1.098484f), new Vector2(-1.148416f, -1.408402f), new Vector2(-1.165634f, -1.78719f), new Vector2(-1.200069f, -2.183195f), new Vector2(-1.200069f, -2.579201f), new Vector2(-1.200069f, -2.940771f), new Vector2(-1.148416f, -3.319559f), new Vector2(-0.8040633f, -3.078513f), new Vector2(-0.5285811f, -2.785812f), new Vector2(-0.3047521f, -2.544765f), new Vector2(-0.04648756f, -2.21763f), new Vector2(0.1256889f, -1.907713f), new Vector2(0.2462122f, -2.286501f), new Vector2(0.3667355f, -2.648071f), new Vector2(0.5561295f, -2.975206f), new Vector2(0.7110883f, -3.336776f) };

        runes[(int)Patern.Flag] = new Vector2[] { new Vector2(-1.234504f, -2.992424f), new Vector2(-1.251722f, -2.561983f), new Vector2(-1.251722f, -2.286501f), new Vector2(-1.251722f, -1.769972f), new Vector2(-1.234504f, -1.580578f), new Vector2(-1.234504f, -1.167355f), new Vector2(-1.217286f, -0.7024792f), new Vector2(-1.200069f, -0.2376029f), new Vector2(-1.200069f, -0.01377374f), new Vector2(-1.200069f, 0.3994495f), new Vector2(-1.182851f, 0.778237f), new Vector2(-1.182851f, 1.088155f), new Vector2(-1.165634f, 1.432507f), new Vector2(-0.8040633f, 1.208678f), new Vector2(-0.4941459f, 0.9504133f), new Vector2(-0.1497935f, 0.657714f), new Vector2(0.09125362f, 0.4683203f), new Vector2(0.4183883f, 0.1756203f), new Vector2(0.6077823f, 0.003443956f), new Vector2(0.9521351f, -0.2376029f), new Vector2(0.6249999f, -0.4786497f), new Vector2(0.297865f, -0.6336087f), new Vector2(-0.02927008f, -0.8230028f), new Vector2(-0.356405f, -0.9951788f), new Vector2(-0.7524104f, -1.115702f), new Vector2(-1.096763f, -1.236225f) };

        runes[(int)Patern.Staf] = new Vector2[] { new Vector2(-1.40668f, -2.665289f), new Vector2(-1.234504f, -2.407024f), new Vector2(-0.959022f, -2.07989f), new Vector2(-0.7179752f, -1.78719f), new Vector2(-0.4424931f, -2.011019f), new Vector2(-0.2530992f, -2.407024f), new Vector2(-0.08092292f, -2.665289f), new Vector2(0.03960051f, -2.234848f), new Vector2(0.03960051f, -1.85606f), new Vector2(0.05681813f, -1.373967f), new Vector2(0.07403574f, -1.115702f), new Vector2(0.09125362f, -0.7196966f), new Vector2(0.108471f, -0.3236911f), new Vector2(0.1256889f, 0.05509675f), new Vector2(0.1601238f, 0.4166669f), new Vector2(0.1945593f, 0.8126724f), new Vector2(0.2289945f, 1.157025f), new Vector2(0.297865f, 1.518595f), new Vector2(0.3495179f, 1.914601f), new Vector2(0.6249999f, 1.639119f), new Vector2(0.9176996f, 1.346419f), new Vector2(1.175964f, 1.12259f), new Vector2(1.399793f, 1.501378f), new Vector2(1.589187f, 1.77686f), new Vector2(1.813016f, 2.086777f) };

        runes[(int)Patern.Corne] = new Vector2[] { new Vector2(-1.255911f, -2.643814f), new Vector2(-1.255911f, -2.865445f), new Vector2(-1.182033f, -3.06245f), new Vector2(-1.108156f, -3.308707f), new Vector2(-0.9850278f, -3.456461f), new Vector2(-0.812648f, -3.604215f), new Vector2(-0.5910168f, -3.702718f), new Vector2(-0.3940111f, -3.75197f), new Vector2(-0.17238f, -3.75197f), new Vector2(0.04925135f, -3.75197f), new Vector2(0.2708826f, -3.727344f), new Vector2(0.4678877f, -3.653467f), new Vector2(0.6156421f, -3.481087f), new Vector2(0.7387705f, -3.284081f), new Vector2(0.8126478f, -3.087076f), new Vector2(0.8372733f, -2.865445f), new Vector2(0.8618991f, -2.643814f), new Vector2(0.8126478f, -2.422182f), new Vector2(0.5910165f, -2.372931f), new Vector2(0.3693853f, -2.397557f), new Vector2(0.1477541f, -2.422182f), new Vector2(-0.07387717f, -2.422182f), new Vector2(-0.2955085f, -2.397557f), new Vector2(-0.5171398f, -2.348306f), new Vector2(-0.7387708f, -2.274428f), new Vector2(-0.886525f, -2.126674f), new Vector2(-1.034279f, -1.929669f), new Vector2(-1.132782f, -1.683412f), new Vector2(-1.206659f, -1.535658f), new Vector2(-1.280536f, -1.314026f), new Vector2(-1.329787f, -1.117021f), new Vector2(-1.379039f, -0.8953896f), new Vector2(-1.42829f, -0.6737584f), new Vector2(-1.452916f, -0.4275015f), new Vector2(-1.477542f, -0.2304959f), new Vector2(-1.502167f, 0.01576066f) };

        runes[(int)Patern.Label] = new Vector2[] { new Vector2(-1.288799f, -1.778003f), new Vector2(-1.120108f, -1.761134f), new Vector2(-0.951417f, -1.761134f), new Vector2(-0.7489878f, -1.761134f), new Vector2(-0.5971661f, -1.761134f), new Vector2(-0.428475f, -1.761134f), new Vector2(-0.2429148f, -1.761134f), new Vector2(-0.07422378f, -1.761134f), new Vector2(0.077598f, -1.744265f), new Vector2(0.2800272f, -1.744265f), new Vector2(0.4318489f, -1.744265f), new Vector2(0.6005398f, -1.744265f), new Vector2(0.769231f, -1.744265f), new Vector2(0.9379219f, -1.744265f), new Vector2(1.123482f, -1.727396f), new Vector2(1.258435f, -1.64305f), new Vector2(1.393387f, -1.524967f), new Vector2(1.494602f, -1.390014f), new Vector2(1.545209f, -1.221323f), new Vector2(1.562078f, -1.052632f), new Vector2(1.578948f, -0.8670716f), new Vector2(1.578948f, -0.6983809f), new Vector2(1.578948f, -0.5296898f), new Vector2(1.562078f, -0.3609989f), new Vector2(1.562078f, -0.1754391f), new Vector2(1.562078f, -0.006748199f), new Vector2(1.562078f, 0.161943f), new Vector2(1.562078f, 0.3306339f), new Vector2(1.562078f, 0.5161941f), new Vector2(1.562078f, 0.684885f), new Vector2(1.545209f, 0.8535761f), new Vector2(1.52834f, 1.022267f), new Vector2(1.511471f, 1.207827f), new Vector2(1.427125f, 1.376518f), new Vector2(1.325911f, 1.477732f), new Vector2(1.174089f, 1.578947f), new Vector2(1.022267f, 1.629554f), new Vector2(0.8367075f, 1.646423f), new Vector2(0.6680163f, 1.663293f), new Vector2(0.4993254f, 1.7139f), new Vector2(0.4318489f, 1.865722f), new Vector2(0.4318489f, 2.034413f), new Vector2(0.4318489f, 2.219973f), new Vector2(0.583671f, 2.287449f), new Vector2(0.6680163f, 2.439271f), new Vector2(0.6680163f, 2.607962f), new Vector2(0.6174092f, 2.776653f), new Vector2(0.448718f, 2.844129f), new Vector2(0.2800272f, 2.860999f), new Vector2(0.1113362f, 2.860999f), new Vector2(-0.0573548f, 2.860999f), new Vector2(-0.2260458f, 2.844129f), new Vector2(-0.4116059f, 2.793522f), new Vector2(-0.5296896f, 2.675438f), new Vector2(-0.5296896f, 2.506748f), new Vector2(-0.3947368f, 2.405533f), new Vector2(-0.3778678f, 2.236842f), new Vector2(-0.3778678f, 2.051282f), new Vector2(-0.3778678f, 1.882591f), new Vector2(-0.4453441f, 1.730769f), new Vector2(-0.614035f, 1.747638f), new Vector2(-0.7995951f, 1.764507f), new Vector2(-0.9682861f, 1.730769f), new Vector2(-1.103239f, 1.629554f), new Vector2(-1.204453f, 1.477732f), new Vector2(-1.255061f, 1.325911f), new Vector2(-1.288799f, 1.15722f), new Vector2(-1.305668f, 0.9885287f), new Vector2(-1.305668f, 0.7860997f), new Vector2(-1.322537f, 0.6005394f), new Vector2(-1.339406f, 0.4655867f), new Vector2(-1.339406f, 0.2800264f), new Vector2(-1.356275f, 0.1282048f), new Vector2(-1.356275f, -0.05735517f), new Vector2(-1.356275f, -0.2260466f), new Vector2(-1.356275f, -0.3947375f), new Vector2(-1.356275f, -0.5634284f), new Vector2(-1.356275f, -0.7321193f), new Vector2(-1.356275f, -0.9176791f), new Vector2(-1.356275f, -1.08637f), new Vector2(-1.356275f, -1.255061f) };

        runes[(int)Patern.Balai] = new Vector2[] { new Vector2(-0.2522465f, 2.573529f), new Vector2(-0.262459f, 2.410131f), new Vector2(-0.2726713f, 2.216095f), new Vector2(-0.2828839f, 2.073121f), new Vector2(-0.2930962f, 1.879085f), new Vector2(-0.2930962f, 1.715687f), new Vector2(-0.262459f, 1.531863f), new Vector2(-0.2318217f, 1.368464f), new Vector2(-0.1807596f, 1.194854f), new Vector2(-0.1501224f, 1.051879f), new Vector2(-0.1296975f, 0.8680561f), new Vector2(-0.1296975f, 0.6842321f), new Vector2(-0.1296975f, 0.5208335f), new Vector2(-0.1296975f, 0.3676472f), new Vector2(-0.1296975f, 0.1940365f), new Vector2(-0.1296975f, 0.02042508f), new Vector2(-0.1296975f, -0.1633987f), new Vector2(-0.1807596f, -0.3370094f), new Vector2(-0.2216093f, -0.4799838f), new Vector2(-0.2828839f, -0.6433823f), new Vector2(-0.4462825f, -0.7046566f), new Vector2(-0.6198937f, -0.6740193f), new Vector2(-0.7935047f, -0.653594f), new Vector2(-0.9671159f, -0.6842322f), new Vector2(-1.130515f, -0.7352936f), new Vector2(-1.283701f, -0.8169932f), new Vector2(-1.416462f, -0.9293294f), new Vector2(-1.549224f, -1.072304f), new Vector2(-1.630923f, -1.18464f), new Vector2(-1.70241f, -1.368464f), new Vector2(-1.712622f, -1.542075f), new Vector2(-1.722835f, -1.695261f), new Vector2(-1.651348f, -1.868872f), new Vector2(-1.559436f, -1.981209f), new Vector2(-1.416462f, -2.083333f), new Vector2(-1.232639f, -2.144608f), new Vector2(-1.06924f, -2.134395f), new Vector2(-0.946691f, -2.022058f), new Vector2(-0.8241419f, -1.909722f), new Vector2(-0.6913804f, -1.787173f), new Vector2(-0.5381943f, -1.879085f), new Vector2(-0.4973446f, -2.042484f), new Vector2(-0.3952205f, -2.185457f), new Vector2(-0.2113968f, -2.205883f), new Vector2(-0.05821064f, -2.185457f), new Vector2(0.09497568f, -2.113971f), new Vector2(0.227737f, -1.970996f), new Vector2(0.3196489f, -1.85866f), new Vector2(0.4115608f, -1.705474f), new Vector2(0.5341096f, -1.828022f), new Vector2(0.6464462f, -1.981209f), new Vector2(0.7792075f, -2.083333f), new Vector2(0.9528189f, -2.103758f), new Vector2(1.106005f, -2.103758f), new Vector2(1.289829f, -2.103758f), new Vector2(1.46344f, -2.073121f), new Vector2(1.616626f, -2.011846f), new Vector2(1.728963f, -1.85866f), new Vector2(1.7596f, -1.705474f), new Vector2(1.7596f, -1.531862f) };

        runes[(int)Patern.Ivrogne] = new Vector2[] { new Vector2(-0.2113968f, 2.900327f), new Vector2(-0.03778579f, 2.900327f), new Vector2(0.07455099f, 2.767566f), new Vector2(0.09497568f, 2.593954f), new Vector2(0.06433848f, 2.420343f), new Vector2(0.05412597f, 2.246732f), new Vector2(0.04391346f, 2.083333f), new Vector2(0.02348877f, 1.89951f), new Vector2(0.003063753f, 1.736111f), new Vector2(-0.007148422f, 1.5625f), new Vector2(-0.01736093f, 1.388889f), new Vector2(0.05412597f, 1.225491f), new Vector2(0.1970998f, 1.133579f), new Vector2(0.3502861f, 1.062092f), new Vector2(0.5238971f, 1.000817f), new Vector2(0.6566584f, 0.8986932f), new Vector2(0.7179331f, 0.7455069f), new Vector2(0.7383578f, 0.5718956f), new Vector2(0.7383578f, 0.3778598f), new Vector2(0.7383578f, 0.2042484f), new Vector2(0.7281457f, 0.04084969f), new Vector2(0.7281457f, -0.1429737f), new Vector2(0.7179331f, -0.2961597f), new Vector2(0.6975081f, -0.4595585f), new Vector2(0.6872959f, -0.6331701f), new Vector2(0.666871f, -0.8169932f), new Vector2(0.666871f, -0.9803917f), new Vector2(0.6464462f, -1.164216f), new Vector2(0.615809f, -1.327615f), new Vector2(0.5749593f, -1.491013f), new Vector2(0.5341096f, -1.664624f), new Vector2(0.3707111f, -1.674837f), new Vector2(0.1766748f, -1.674837f), new Vector2(0.01327626f, -1.633987f), new Vector2(-0.1705471f, -1.623774f), new Vector2(-0.3339459f, -1.644199f), new Vector2(-0.4973446f, -1.664624f), new Vector2(-0.6607434f, -1.685049f), new Vector2(-0.8343544f, -1.685049f), new Vector2(-0.9875407f, -1.613562f), new Vector2(-1.130515f, -1.511438f), new Vector2(-1.140727f, -1.337826f), new Vector2(-1.140727f, -1.164216f), new Vector2(-1.140727f, -0.9803917f), new Vector2(-1.140727f, -0.7965684f), new Vector2(-1.140727f, -0.6331701f), new Vector2(-1.140727f, -0.4595585f), new Vector2(-1.120302f, -0.2961597f), new Vector2(-1.130515f, -0.1123362f), new Vector2(-1.130515f, 0.04084969f), new Vector2(-1.120302f, 0.2246735f), new Vector2(-1.099877f, 0.3982842f), new Vector2(-1.079453f, 0.5718956f), new Vector2(-1.038603f, 0.7250819f), new Vector2(-0.9773282f, 0.8884805f), new Vector2(-0.895629f, 1.041667f), new Vector2(-0.7220178f, 1.092729f), new Vector2(-0.5586191f, 1.092729f), new Vector2(-0.4462825f, 1.245915f), new Vector2(-0.4258577f, 1.399101f), new Vector2(-0.4054328f, 1.582925f), new Vector2(-0.4054328f, 1.746324f), new Vector2(-0.385008f, 1.919935f), new Vector2(-0.3747956f, 2.103758f), new Vector2(-0.3543708f, 2.277369f), new Vector2(-0.3543708f, 2.440768f) };

        runes[(int)Patern.Empoule] = new Vector2[] { new Vector2(-0.5262209f, -1.077586f), new Vector2(-0.5082612f, -0.8979893f), new Vector2(-0.5262209f, -0.736351f), new Vector2(-0.5441806f, -0.5567532f), new Vector2(-0.5801005f, -0.3951156f), new Vector2(-0.6160199f, -0.215518f), new Vector2(-0.7058186f, -0.05388021f), new Vector2(-0.7776579f, 0.07183838f), new Vector2(-0.8674566f, 0.2334766f), new Vector2(-0.9213359f, 0.3951142f), new Vector2(-0.993175f, 0.5567524f), new Vector2(-1.082974f, 0.71839f), new Vector2(-1.172773f, 0.8620682f), new Vector2(-1.226652f, 1.005747f), new Vector2(-1.262572f, 1.185344f), new Vector2(-1.280531f, 1.346982f), new Vector2(-1.262572f, 1.54454f), new Vector2(-1.208692f, 1.688218f), new Vector2(-1.136853f, 1.849856f), new Vector2(-1.047054f, 1.993534f), new Vector2(-0.9213359f, 2.173132f), new Vector2(-0.8494968f, 2.29885f), new Vector2(-0.7596982f, 2.406609f), new Vector2(-0.6160199f, 2.514368f), new Vector2(-0.4364222f, 2.586206f), new Vector2(-0.292744f, 2.640086f), new Vector2(-0.07722667f, 2.711925f), new Vector2(-0.005387552f, 2.747844f), new Vector2(0.2101296f, 2.801724f), new Vector2(0.3358478f, 2.819684f), new Vector2(0.5154458f, 2.819684f), new Vector2(0.6591237f, 2.801724f), new Vector2(0.8566815f, 2.747844f), new Vector2(0.9823996f, 2.658045f), new Vector2(1.108118f, 2.532327f), new Vector2(1.197917f, 2.406609f), new Vector2(1.305676f, 2.244971f), new Vector2(1.377515f, 2.101293f), new Vector2(1.467314f, 1.957614f), new Vector2(1.539153f, 1.813936f), new Vector2(1.593032f, 1.616379f), new Vector2(1.628951f, 1.49066f), new Vector2(1.646911f, 1.293103f), new Vector2(1.664871f, 1.149425f), new Vector2(1.628951f, 0.9698269f), new Vector2(1.575072f, 0.8081895f), new Vector2(1.503233f, 0.6106319f), new Vector2(1.449354f, 0.4849136f), new Vector2(1.377515f, 0.3412347f), new Vector2(1.287716f, 0.197557f), new Vector2(1.144038f, 0.07183838f), new Vector2(1.036279f, -0.0359199f), new Vector2(0.9464802f, -0.1975582f), new Vector2(0.8746412f, -0.3412361f), new Vector2(0.8207617f, -0.520834f), new Vector2(0.7668824f, -0.7004318f), new Vector2(0.730963f, -0.8441095f), new Vector2(0.7130032f, -1.023708f) };

        runes[(int)Patern.Epice] = new Vector2[] { new Vector2(0.6950435f, 2.442528f), new Vector2(0.5872847f, 2.29885f), new Vector2(0.4615663f, 2.155172f), new Vector2(0.3358478f, 1.993534f), new Vector2(0.2640088f, 1.885775f), new Vector2(0.1921699f, 1.724138f), new Vector2(0.1562504f, 1.580459f), new Vector2(0.1382903f, 1.382902f), new Vector2(0.1382903f, 1.185344f), new Vector2(0.1382903f, 1.023706f), new Vector2(0.1562504f, 0.8979881f), new Vector2(0.2280894f, 0.6645107f), new Vector2(0.2640088f, 0.5747122f), new Vector2(0.3717676f, 0.3951142f), new Vector2(0.4256468f, 0.3232753f), new Vector2(0.5334055f, 0.1616378f), new Vector2(0.6411643f, 0.01795888f), new Vector2(0.7130032f, -0.1077585f), new Vector2(0.8028019f, -0.3232765f), new Vector2(0.8207617f, -0.3771563f), new Vector2(0.9105607f, -0.5747132f), new Vector2(0.9644399f, -0.6824713f), new Vector2(1.018319f, -0.8441095f), new Vector2(1.018319f, -1.023708f), new Vector2(0.9464802f, -1.221265f), new Vector2(0.892601f, -1.329023f), new Vector2(0.7848422f, -1.490662f), new Vector2(0.6411643f, -1.63434f), new Vector2(0.5154458f, -1.706179f), new Vector2(0.3538078f, -1.778018f), new Vector2(0.2280894f, -1.795978f) };

        runes[(int)Patern.O] = new Vector2[] { new Vector2(-1.214038f, 0.6882443f), new Vector2(-1.114832f, 0.8556551f), new Vector2(-1.009425f, 0.9920635f), new Vector2(-0.8544148f, 1.122272f), new Vector2(-0.7304068f, 1.202877f), new Vector2(-0.5939981f, 1.264881f), new Vector2(-0.3769841f, 1.320685f), new Vector2(-0.2219743f, 1.333085f), new Vector2(-0.06696454f, 1.333085f), new Vector2(0.07564466f, 1.333085f), new Vector2(0.2678571f, 1.302083f), new Vector2(0.453869f, 1.258681f), new Vector2(0.6212797f, 1.202877f), new Vector2(0.7266865f, 1.147074f), new Vector2(0.8568947f, 1.035466f), new Vector2(0.9871032f, 0.9052581f), new Vector2(1.10491f, 0.7502478f), new Vector2(1.179316f, 0.6200397f), new Vector2(1.25992f, 0.4092262f), new Vector2(1.278522f, 0.3410218f), new Vector2(1.297123f, 0.1426091f), new Vector2(1.297123f, -0.0558033f), new Vector2(1.297123f, -0.1984124f), new Vector2(1.290922f, -0.3472221f), new Vector2(1.25372f, -0.5580354f), new Vector2(1.210317f, -0.6882439f), new Vector2(1.129712f, -0.8804562f), new Vector2(1.055307f, -1.016865f), new Vector2(0.9623015f, -1.140873f), new Vector2(0.8630953f, -1.246279f), new Vector2(0.6956846f, -1.376488f), new Vector2(0.5592758f, -1.444692f), new Vector2(0.4104662f, -1.506696f), new Vector2(0.2554563f, -1.550099f), new Vector2(0.02604157f, -1.5687f), new Vector2(-0.1289683f, -1.5625f), new Vector2(-0.2777778f, -1.531498f), new Vector2(-0.451389f, -1.506696f), new Vector2(-0.5939981f, -1.506696f), new Vector2(-0.7924107f, -1.450893f), new Vector2(-0.9164188f, -1.370287f), new Vector2(-1.040426f, -1.25248f), new Vector2(-1.152034f, -1.128472f), new Vector2(-1.288442f, -0.9920635f), new Vector2(-1.369048f, -0.861855f), new Vector2(-1.431051f, -0.700645f), new Vector2(-1.462054f, -0.4650295f), new Vector2(-1.462054f, -0.3720238f), new Vector2(-1.455853f, -0.1860118f), new Vector2(-1.437252f, -0.03720236f), new Vector2(-1.412451f, 0.1240082f), new Vector2(-1.331845f, 0.3038197f) };
    }

    public Vector2[] GetRune(Patern _patern)
    {
        return runes[(int)_patern];
    }

}
