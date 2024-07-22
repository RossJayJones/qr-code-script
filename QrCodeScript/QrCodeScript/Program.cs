using QRCoder;
using static QRCoder.PayloadGenerator;

var qrGenerator = new QRCodeGenerator();
var count = 0;

foreach (var data in File.ReadAllLines("vouchers.csv").Select(d => d.Split(';')).Skip(1))
{
    count++;

    var generator = new Url(data[1]);
    string payload = generator.ToString();

    var qrCodeData = qrGenerator.CreateQrCode(payload, QRCodeGenerator.ECCLevel.Q);
    var qrCode = new PngByteQRCode(qrCodeData);
    var graphic = qrCode.GetGraphic(40);

    File.WriteAllBytes($"{count}.png", graphic);
}
