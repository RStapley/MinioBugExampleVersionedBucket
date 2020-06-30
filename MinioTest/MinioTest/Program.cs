using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinioTest
{
    class Program
    {

        static void Main(string[] args)
        {
            var config = new AmazonS3Config
            {
                ServiceURL = "http://localhost:9000",
                ForcePathStyle=true
                
            };

            AmazonS3Client s3Client = new AmazonS3Client("minioadmin", "minioadmin", config);

            PutBucketRequest pbr = new PutBucketRequest();
            pbr.BucketName = "testbucket";

            S3BucketVersioningConfig sbvc = new S3BucketVersioningConfig();
            sbvc.Status = VersionStatus.Enabled;

            PutBucketVersioningRequest pbvr = new PutBucketVersioningRequest();
            pbvr.BucketName = "testbucket";
            pbvr.VersioningConfig = sbvc;

            PutObjectRequest por = new PutObjectRequest();
            por.BucketName = "testbucket";
            por.Key = "testKey";
            por.ContentBody = "test";


            s3Client.PutBucket(pbr);
            s3Client.PutBucketVersioning(pbvr);
            s3Client.PutObject(por);


            Console.Out.WriteLine("Done");
        }
    }
}
