pipeline {
    agent any
    triggers {
        pollSCM('1 * * * *')
        //cron('10 * * * *')
    }
    stages {
        stage('Setup') {
            steps {
                dir("Backend/Test"){
                    sh "rm -rf TestResults"
                }
            }
        }
        stage('Build') {
            steps {
                sh 'dotnet restore Backend/API/API.csproj'
                sh 'dotnet build Backend/API/API.csproj'
                echo 'build complete'
            }
        }
        stage('Test') {
            steps {
                dir("Backend/Test"){
                    sh "dotnet add package coverlet.collector"
                    sh "mkdir TestResults"
                    sh "dotnet test --collect:'XPlat Code Coverage'"
                    sh "ls -R TestResults"
                }
            }
            post {
                success{
                    sh "ls -R Backend/Test/TestResults"
                    archiveArtifacts "Backend/Test/TestResults/*/coverage.cobertura.xml"
                    publishCoverage adapters: [istanbulCoberturaAdapter(path: "Backend/Test/TestResults/*/coverage.cobertura.xml", thresholds:
                    [[failUnhealthy: true, thresholdTarget: 'Conditional', unhealthyThreshold: 80.0, unstableThreshold: 50.0]])], checksName: '',
                    sourceFileResolver: sourceFiles('NEVER_STORE')
                }
            }
        }
        stage('Deploy') {
            steps {
                // dotnet publish -o ../../outputs
                echo 'deploy'
            }
        }
    }
}